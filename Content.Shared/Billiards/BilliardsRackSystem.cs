using Robust.Shared.Containers;
using Robust.Shared.Map;
using System.Numerics;
using Robust.Shared.Network;

namespace Content.Shared.Billiards;

public sealed partial class BilliardsBallSpawnerSystem : EntitySystem
{
    [Dependency] private SharedTransformSystem _transform = default!;
    [Dependency] private INetManager _net = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<BilliardsSpawnerComponent, MapInitEvent>(OnMapInit);
    }

    private void OnMapInit(EntityUid uid, BilliardsSpawnerComponent component, MapInitEvent args)
    {
        if (_net.IsClient)
            return;

        var xform = Transform(uid);

        if (xform.ParentUid.IsValid() && HasComp<ContainerManagerComponent>(xform.ParentUid))
            return;

        var originPos = _transform.GetWorldPosition(xform);
        var worldRot = _transform.GetWorldRotation(xform);
        var mapId = xform.MapID;

        float spacing = component.BallSpacing;
        float rowStepY = spacing * 0.866025f; // MathF.Sqrt(3) / 2

        for (int row = 0; row < component.Rows; row++)
        {
            float localY = -(row * rowStepY);
            float startX = -(row * spacing * 0.5f);

            for (int col = 0; col <= row; col++)
            {
                float localX = startX + (col * spacing);
                var localPos = new Vector2(localX, localY);
                var rotatedPos = worldRot.RotateVec(localPos);
                var finalPos = originPos + rotatedPos;

                Spawn(component.BallPrototype, new MapCoordinates(finalPos, mapId));
            }
        }

        QueueDel(uid);
    }
}
