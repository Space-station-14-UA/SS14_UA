using Content.Client.Gameplay; // Не забудьте цей using для GameplayStateBase
using Content.Client.Viewport;
using Content.Shared.Billiards;
using Content.Shared.Hands.Components;
using Content.Shared.Hands.EntitySystems;
using Robust.Client.Graphics;
using Robust.Client.Input;
using Robust.Client.Player;
using Robust.Client.State;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.CustomControls;
using Robust.Shared.Enums;
using Robust.Shared.Map;
using Robust.Shared.Maths;
using System;

namespace Content.Client.Billiards;

public sealed class BilliardAimOverlay : Overlay
{
    private readonly IEntityManager _entManager;
    private readonly IPlayerManager _playerManager;
    private readonly IInputManager _inputManager;
    private readonly IStateManager _stateManager;
    private readonly IUserInterfaceManager _uiManager;
    private readonly SharedTransformSystem _transform;
    private readonly SharedHandsSystem _hands;

    public override OverlaySpace Space => OverlaySpace.WorldSpace;

    public BilliardAimOverlay(
        IEntityManager entManager,
        IPlayerManager playerManager,
        IInputManager inputManager,
        IStateManager stateManager,
        IUserInterfaceManager uiManager)
    {
        _entManager = entManager;
        _playerManager = playerManager;
        _inputManager = inputManager;
        _stateManager = stateManager;
        _uiManager = uiManager;

        _transform = _entManager.System<SharedTransformSystem>();
        _hands = _entManager.System<SharedHandsSystem>();
    }

    protected override void Draw(in OverlayDrawArgs args)
    {
        var handle = args.WorldHandle;

        var player = _playerManager.LocalSession?.AttachedEntity;
        if (player == null) return;

        if (!_entManager.TryGetComponent<HandsComponent>(player, out var hands)) return;

        var activeHandEntity = _hands.GetActiveItem((player.Value, hands));
        if (activeHandEntity == null || !_entManager.HasComponent<BilliardCueComponent>(activeHandEntity))
            return;

        var currentState = _stateManager.CurrentState;
        if (currentState is not GameplayStateBase screen) return;

        EntityUid? targetBall = null;

        if (_uiManager.CurrentlyHovered is IViewportControl vp && _inputManager.MouseScreenPosition.IsValid)
        {
            var mousePosWorld = vp.PixelToMap(_inputManager.MouseScreenPosition.Position);

            if (vp is ScalingViewport svp)
            {
                targetBall = screen.GetClickedEntity(mousePosWorld, svp.Eye);
            }
            else
            {
                targetBall = screen.GetClickedEntity(mousePosWorld);
            }
        }

        if (targetBall == null || !_entManager.HasComponent<BilliardBallComponent>(targetBall.Value))
            return;

        var playerPos = _transform.GetMapCoordinates(player.Value);
        var ballPos = _transform.GetMapCoordinates(targetBall.Value);

        if (playerPos.MapId != ballPos.MapId) return;

        var diff = ballPos.Position - playerPos.Position;

        if (diff.LengthSquared() < 0.001f) return;

        var dir = diff.Normalized();
        var start = ballPos.Position;

        float aimDistance = 0.4f;
        float dashLength = 0.05f;
        float gapLength = 0.05f;

        for (float d = 0; d < aimDistance; d += dashLength + gapLength)
        {
            var p1 = start + dir * d;
            var p2 = start + dir * Math.Min(d + dashLength, aimDistance);

            handle.DrawLine(p1, p2, Color.White);
        }
    }
}
