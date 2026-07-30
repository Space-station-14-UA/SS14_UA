using Robust.Shared.Containers;
using Robust.Shared.Map;
using System.Numerics;
using Robust.Shared.Network;
using Robust.Shared.Random;
using Robust.Shared.Serialization;

namespace Content.Shared.Billiards;

public sealed partial class BilliardBallSpawnerSystem : EntitySystem
{
    [Dependency] private SharedTransformSystem _transform = default!;
    [Dependency] private INetManager _net = default!;
    [Dependency] private IRobustRandom _random = default!;
    [Dependency] private SharedAppearanceSystem _appearance = default!;

    private readonly Color[] _poolColors =
    {
        Color.FromHex("#F1B82D"), // 1/9 Жовтий
        Color.FromHex("#1958A7"), // 2/10 Синій
        Color.FromHex("#D93126"), // 3/11 Червоний
        Color.FromHex("#482563"), // 4/12 Фіолетовий
        Color.FromHex("#E67425"), // 5/13 Помаранчевий
        Color.FromHex("#1E7535"), // 6/14 Зелений
        Color.FromHex("#7B2D26")  // 7/15 Бордовий
    };

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<BilliardSpawnerComponent, MapInitEvent>(OnMapInit);
    }

    private void OnMapInit(EntityUid uid, BilliardSpawnerComponent component, MapInitEvent args)
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
        float rowStepY = spacing * 0.866025f;

        var ballSet = GenerateBallSet(component.GameType);
        int ballIndex = 0;

        for (int row = 0; row < component.Rows; row++)
        {
            float localY = -(row * rowStepY);
            float startX = -(row * spacing * 0.5f);

            for (int col = 0; col <= row; col++)
            {
                if (ballIndex >= ballSet.Count) break;

                float localX = startX + (col * spacing);
                var localPos = new Vector2(localX, localY);
                var finalPos = originPos + worldRot.RotateVec(localPos);

                var ballUid = Spawn(component.BallPrototype, new MapCoordinates(finalPos, mapId));
                ApplyBallAppearance(ballUid, ballSet[ballIndex].Color, ballSet[ballIndex].IsStriped);

                ballIndex++;
            }
        }

        var cueBallLocalPos = new Vector2(0, spacing * 5);
        var cueBallFinalPos = originPos + worldRot.RotateVec(cueBallLocalPos);

        var cueBallUid = Spawn(component.BallPrototype, new MapCoordinates(cueBallFinalPos, mapId));
        ApplyBallAppearance(cueBallUid, Color.White, false);

        QueueDel(uid);
    }

    private List<(Color Color, bool IsStriped)> GenerateBallSet(BilliardGameType type)
    {
        var set = new List<(Color, bool)>();

        if (type == BilliardGameType.Pyramid)
        {
            for (int i = 0; i < 15; i++)
            {
                set.Add((Color.White, false));
            }
        }
        else if (type == BilliardGameType.AmericanPool)
        {
            var randomSet = new List<(Color, bool)>();

            for (int i = 0; i < 7; i++)
            {
                randomSet.Add((_poolColors[i], false));
                randomSet.Add((_poolColors[i], true));
            }

            _random.Shuffle(randomSet);

            for (int i = 0; i < 15; i++)
            {
                if (i == 4)
                {
                    set.Add((Color.Black, false));
                }
                else
                {
                    set.Add(randomSet[0]);
                    randomSet.RemoveAt(0);
                }
            }
        }

        return set;
    }

    private void ApplyBallAppearance(EntityUid uid, Color color, bool isStriped)
    {
        _appearance.SetData(uid, BilliardVisuals.Color, color);
        _appearance.SetData(uid, BilliardVisuals.Stripe, isStriped);
    }
}

[Serializable, NetSerializable]
public enum BilliardVisuals : byte
{
    Color,
    Stripe
}

[Serializable, NetSerializable]
public enum BilliardVisualLayers : byte
{
    Base,
    Stripe
}

public enum BilliardGameType : byte
{
    Pyramid,
    AmericanPool
}
