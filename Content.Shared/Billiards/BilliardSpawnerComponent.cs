using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Shared.Billiards;

[RegisterComponent, NetworkedComponent]
public sealed partial class BilliardSpawnerComponent : Component
{
    [DataField]
    public EntProtoId BallPrototype = "BilliardsBall";

    [DataField]
    public float BallSpacing = 0.13f;

    [DataField]
    public int Rows = 5;

    [DataField]
    public BilliardGameType GameType = BilliardGameType.Pyramid;
}
