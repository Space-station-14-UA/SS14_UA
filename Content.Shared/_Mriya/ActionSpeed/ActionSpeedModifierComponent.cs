using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Shared._Mriya.ActionSpeed;

/// <summary>
/// Mriya: компонент для зміни швидкості дій
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class ActionSpeedModifierComponent : Component
{
    [DataField]
    public Dictionary<ProtoId<ActionSpeedCategoryPrototype>, float> Multipliers = new();
}
