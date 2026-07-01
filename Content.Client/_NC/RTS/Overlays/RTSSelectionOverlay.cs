using System.Numerics;
using Content.Client._NC.RTS.Systems;
using Content.Shared._NC.RTS.Components;
using Robust.Client.Graphics;
using Robust.Shared.Enums;
using Robust.Shared.GameObjects;
using Robust.Shared.Map;
using Robust.Shared.Maths;

namespace Content.Client._NC.RTS.Overlays;

public sealed class RTSSelectionOverlay : Overlay
{
    private readonly IEntityManager _entManager;
    private readonly RTSSelectionSystem _selectionSystem;

    public override OverlaySpace Space => OverlaySpace.ScreenSpace | OverlaySpace.WorldSpace;

    public RTSSelectionOverlay(RTSSelectionSystem selectionSystem)
    {
        _selectionSystem = selectionSystem;
        _entManager = IoCManager.Resolve<IEntityManager>();
    }

    protected override void Draw(in OverlayDrawArgs args)
    {
        if (args.Space == OverlaySpace.ScreenSpace)
            DrawScreen(args);
        else if (args.Space == OverlaySpace.WorldSpace)
            DrawWorld(args);
    }

    private void DrawScreen(in OverlayDrawArgs args)
    {
        if (!_selectionSystem.IsDragging)
            return;

        var start = _selectionSystem.DragStart.Position;
        var end = _selectionSystem.DragEnd.Position;
        if (Vector2.DistanceSquared(start, end) < 16f)
            return;

        var box = new UIBox2(
            MathF.Min(start.X, end.X),
            MathF.Min(start.Y, end.Y),
            MathF.Max(start.X, end.X),
            MathF.Max(start.Y, end.Y));

        args.ScreenHandle.DrawRect(box, Color.Green.WithAlpha(0.1f));
        args.ScreenHandle.DrawRect(box, Color.Green, false);
    }

    private void DrawWorld(in OverlayDrawArgs args)
    {
        var transformSystem = _entManager.System<SharedTransformSystem>();

        foreach (var uid in _selectionSystem.SelectedEntities)
        {
            if (!_entManager.TryGetComponent(uid, out TransformComponent? xform) ||
                !_entManager.TryGetComponent(uid, out RTSControllableComponent? rts) ||
                xform.MapID != args.MapId ||
                rts.Destination == null)
            {
                continue;
            }

            var targetPos = rts.Destination.Value.ToMap(_entManager, transformSystem);
            if (targetPos.MapId != args.MapId)
                continue;

            args.WorldHandle.DrawLine(xform.MapPosition.Position, targetPos.Position, Color.Green.WithAlpha(0.4f));
            args.WorldHandle.DrawCircle(targetPos.Position, 0.2f, Color.Green.WithAlpha(0.5f));
        }
    }
}
