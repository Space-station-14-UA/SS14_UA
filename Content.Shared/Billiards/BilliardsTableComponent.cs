using Content.Shared.Interaction;
using Robust.Shared.Containers;
using Robust.Shared.GameStates;
using Robust.Shared.Map;
using Robust.Shared.Prototypes;
using System.Numerics;
using Robust.Shared.Network;

namespace Content.Shared.Billiards;

[RegisterComponent, NetworkedComponent]
public sealed partial class BilliardsTableComponent : Component;

[RegisterComponent, NetworkedComponent]
public sealed partial class BilliardsBallComponent : Component;

[RegisterComponent, NetworkedComponent]
public sealed partial class BilliardsSpawnerComponent : Component
{
    [DataField]
    public EntProtoId BallPrototype = "BilliardsBall";

    [DataField]
    public float BallSpacing = 0.13f;

    [DataField]
    public int Rows = 5;
}

public sealed partial class BilliardsRackSystem : EntitySystem
{
    [Dependency] private SharedTransformSystem _transform = default!;
    [Dependency] private INetManager _net = default!;

    public override void Initialize()
    {
        base.Initialize();

        // Спавн кулей при використанні трикутника в руках/на столі
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
        var worldRot = _transform.GetWorldRotation(xform); // Отримуємо кут повороту спавнера
        var mapId = xform.MapID;

        float spacing = component.BallSpacing;
        // Змінив назву змінної на rowStepY для логічної зрозумілості
        float rowStepY = spacing * 0.866025f; // MathF.Sqrt(3) / 2

        for (int row = 0; row < component.Rows; row++)
        {
            // Розраховуємо локальний зсув по осі Y
            // Використовуємо мінус, щоб ряди йшли вниз, а вершина (0,0) дивилася вгору
            float localY = -(row * rowStepY);

            // Розраховуємо початковий зсув по осі X для цього ряду (щоб він був по центру)
            float startX = -(row * spacing * 0.5f);

            for (int col = 0; col <= row; col++)
            {
                // Локальний зсув по осі X для конкретної кульки
                float localX = startX + (col * spacing);
                var localPos = new Vector2(localX, localY);

                // Повертаємо локальний вектор на кут нашого спавнера/столу
                var rotatedPos = worldRot.RotateVec(localPos);

                // Отримуємо фінальну світову позицію
                var finalPos = originPos + rotatedPos;

                Spawn(component.BallPrototype, new MapCoordinates(finalPos, mapId));
            }
        }

        QueueDel(uid);
    }
}
