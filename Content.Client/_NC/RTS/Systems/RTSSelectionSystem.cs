using System.Linq;
using System.Numerics;
using Content.Client.Administration.Managers;
using Content.Client._NC.RTS.Components;
using Content.Client._NC.RTS.Overlays;
using Content.Client._NC.RTS.UI;
using Content.Shared.Administration;
using Content.Shared._NC.RTS.Components;
using Content.Shared._NC.RTS.Events;
using Content.Shared.Ghost;
using Content.Shared.Input;
using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Shared.Input;
using Robust.Shared.Input.Binding;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;
using static Robust.Shared.Input.Binding.PointerInputCmdHandler;

namespace Content.Client._NC.RTS.Systems;

public sealed class RTSSelectionSystem : EntitySystem
{
    [Dependency] private readonly IClientAdminManager _adminManager = default!;
    [Dependency] private readonly IEyeManager _eyeManager = default!;
    [Dependency] private readonly IInputManager _inputManager = default!;
    [Dependency] private readonly EntityLookupSystem _lookup = default!;
    [Dependency] private readonly IOverlayManager _overlayManager = default!;
    [Dependency] private readonly IPlayerManager _playerManager = default!;
    [Dependency] private readonly IPrototypeManager _prototypeManager = default!;

    private RTSCommandType? _pendingCommand;
    private RTSSelectionOverlay? _overlay;
    private RTSControlWindow? _window;

    public bool IsDragging { get; private set; }
    public ScreenCoordinates DragStart { get; private set; }
    public ScreenCoordinates DragEnd { get; private set; }
    public HashSet<EntityUid> SelectedEntities { get; } = new();

    public override void Initialize()
    {
        base.Initialize();

        _overlay = new RTSSelectionOverlay(this);
        _overlayManager.AddOverlay(_overlay);

        CommandBinds.Builder
            .Bind(EngineKeyFunctions.Use, new PointerInputCmdHandler(HandleUse, ignoreUp: false, outsidePrediction: true))
            .Bind(EngineKeyFunctions.UseSecondary, new PointerInputCmdHandler(HandleRightClick, ignoreUp: false, outsidePrediction: true))
            .Bind(ContentKeyFunctions.RTSHoldPosition, InputCmdHandler.FromDelegate(HandleHoldPosition))
            .Register<RTSSelectionSystem>();
    }

    public override void Shutdown()
    {
        ClearSelection();
        CommandBinds.Unregister<RTSSelectionSystem>();

        if (_overlay != null)
            _overlayManager.RemoveOverlay(_overlay);

        _window?.Dispose();
        _window = null;

        base.Shutdown();
    }

    public override void FrameUpdate(float frameTime)
    {
        base.FrameUpdate(frameTime);

        if (!IsModeActive())
        {
            if (IsDragging)
                IsDragging = false;

            if (SelectedEntities.Count > 0 || _window?.IsOpen == true || _pendingCommand != null)
                ClearSelection();

            _pendingCommand = null;
            _window?.Close();
            return;
        }

        // Drop stale drag state when the button-up packet is missed.
        if (IsDragging && !_inputManager.DownKeyFunctions.Contains(EngineKeyFunctions.Use))
            IsDragging = false;

        if (IsDragging)
            DragEnd = _inputManager.MouseScreenPosition;
    }

    private bool HandleUse(in PointerInputCmdArgs args)
    {
        if (!IsModeActive())
            return false;

        if (args.State == BoundKeyState.Down)
        {
            if (_pendingCommand != null)
            {
                IssueCommand(_pendingCommand.Value, args.ScreenCoordinates);
                _pendingCommand = null;
                return true;
            }

            if (_inputManager.IsKeyDown(Keyboard.Key.A))
            {
                IssueCommand(RTSCommandType.AttackMove, args.ScreenCoordinates);
                return true;
            }

            if (IsDragging)
                return true;

            IsDragging = true;
            DragStart = args.ScreenCoordinates;
            DragEnd = args.ScreenCoordinates;
            return true;
        }

        if (args.State != BoundKeyState.Up || !IsDragging)
            return false;

        IsDragging = false;
        SelectEntities();
        return true;
    }

    private bool HandleRightClick(in PointerInputCmdArgs args)
    {
        if (!IsModeActive() || SelectedEntities.Count == 0 || args.State != BoundKeyState.Down)
            return false;

        var mapCoords = _eyeManager.ScreenToMap(args.ScreenCoordinates);
        var targetEntity = GetEntityUnderPosition(mapCoords);

        if (targetEntity != null)
            IssueCommand(RTSCommandType.AttackTarget, args.ScreenCoordinates, targetEntity);
        else
            IssueCommand(RTSCommandType.Move, args.ScreenCoordinates);

        return true;
    }

    private void SelectEntities()
    {
        ClearSelection();

        var startMap = _eyeManager.ScreenToMap(DragStart);
        var endMap = _eyeManager.ScreenToMap(DragEnd);
        if (startMap.MapId != endMap.MapId)
            return;

        var box = Box2.FromTwoPoints(startMap.Position, endMap.Position);
        if (box.Size.LengthSquared() < 0.01f)
            box = box.Enlarged(0.1f);

        var entities = _lookup
            .GetEntitiesIntersecting(startMap.MapId, box)
            .Where(uid => HasComp<RTSControllableComponent>(uid));

        foreach (var uid in entities)
        {
            SelectedEntities.Add(uid);
            ApplyOutline(uid);
        }

        UpdateUI();
    }

    private void ClearSelection()
    {
        foreach (var uid in SelectedEntities)
        {
            RemoveOutline(uid);
        }

        SelectedEntities.Clear();
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (SelectedEntities.Count == 0)
        {
            _window?.Close();
            _pendingCommand = null;
            return;
        }

        if (_window == null || _window.Disposed)
        {
            _window = new RTSControlWindow();
            _window.OnCommandIssued += type =>
            {
                if (type == RTSCommandType.HoldPosition)
                    IssueCommand(type, _inputManager.MouseScreenPosition);
                else
                    _pendingCommand = type;
            };
            _window.OnStopIssued += () => IssueCommand(RTSCommandType.Stop, _inputManager.MouseScreenPosition);
        }

        if (!_window.IsOpen)
            _window.OpenCentered();

        _window.UpdateSelectionCount(SelectedEntities.Count);
    }

    private void ApplyOutline(EntityUid uid)
    {
        if (!TryComp(uid, out SpriteComponent? sprite))
            return;

        var selected = EnsureComp<RTSSelectedComponent>(uid);
        if (selected.Shader != null)
            return;

        var shader = _prototypeManager.Index<ShaderPrototype>("SelectionOutlineInrange").InstanceUnique();
        selected.Shader = shader;
        sprite.PostShader = shader;
    }

    private void RemoveOutline(EntityUid uid)
    {
        if (Deleted(uid))
            return;

        if (!TryComp(uid, out RTSSelectedComponent? selected))
            return;

        if (TryComp(uid, out SpriteComponent? sprite) && sprite.PostShader == selected.Shader)
            sprite.PostShader = null;

        RemComp(uid, selected);
    }

    private void IssueCommand(RTSCommandType type, ScreenCoordinates screenCoords, EntityUid? target = null)
    {
        if (SelectedEntities.Count == 0)
            return;

        var mapCoords = _eyeManager.ScreenToMap(screenCoords);
        var targetEntity = target ?? GetEntityUnderPosition(mapCoords);
        var netEntities = new List<NetEntity>();

        foreach (var uid in SelectedEntities)
        {
            if (Exists(uid))
                netEntities.Add(GetNetEntity(uid));
        }

        if (netEntities.Count == 0)
            return;

        RaiseNetworkEvent(new RTSCommandEvent(
            netEntities,
            type,
            targetEntity == null ? mapCoords.Position : null,
            targetEntity != null ? GetNetEntity(targetEntity.Value) : null));
    }

    private void HandleHoldPosition(ICommonSession? session)
    {
        if (!IsModeActive())
            return;

        IssueCommand(RTSCommandType.HoldPosition, _inputManager.MouseScreenPosition);
    }

    private bool IsModeActive()
    {
        if (!_adminManager.IsActive() || !_adminManager.HasFlag(AdminFlags.Admin))
            return false;

        var attached = _playerManager.LocalSession?.AttachedEntity;
        if (attached == null)
            return false;

        return TryComp(attached.Value, out RTSModeComponent? mode) && mode.Enabled;
    }

    private EntityUid? GetEntityUnderPosition(MapCoordinates mapCoords)
    {
        var box = Box2.CenteredAround(mapCoords.Position, new Vector2(0.4f, 0.4f));

        foreach (var uid in _lookup.GetEntitiesIntersecting(mapCoords.MapId, box))
        {
            if (SelectedEntities.Contains(uid) ||
                !HasComp<SpriteComponent>(uid) ||
                HasComp<GhostComponent>(uid))
            {
                continue;
            }

            return uid;
        }

        return null;
    }
}
