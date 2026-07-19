using Robust.Shared.Prototypes;

namespace Content.Shared._Mriya.ActionSpeed;

[Prototype("actionSpeedCategory")]
public sealed partial class ActionSpeedCategoryPrototype : IPrototype
{
    [IdDataField]
    public string ID { get; private set; } = default!;
}
