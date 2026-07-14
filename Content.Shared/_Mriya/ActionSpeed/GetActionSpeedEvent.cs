using Robust.Shared.Prototypes;

namespace Content.Shared._Mriya.ActionSpeed;

[ByRefEvent]
public record struct GetActionSpeedEvent(ProtoId<ActionSpeedCategoryPrototype> Category, float Multiplier);
