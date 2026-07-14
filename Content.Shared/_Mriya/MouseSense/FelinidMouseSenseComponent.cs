using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Shared._Mriya.MouseSense;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class FelinidMouseSenseComponent : Component
{
    [DataField]
    public EntProtoId Action = "ActionMRMouseSense";

    [DataField, AutoNetworkedField]
    public EntityUid? ActionEntity;
}
