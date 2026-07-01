using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;

namespace Content.Shared._NC.RTS.Components;

/// <summary>
/// Runtime admin-only state for the local RTS control mode on the currently attached entity.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class RTSModeComponent : Component
{
    [DataField]
    public EntProtoId ToggleAction = "ActionNCRTSToggle";

    [DataField]
    public EntityUid? ToggleActionEntity;

    /// <summary>
    /// True while the admin has RTS input mode armed on this entity.
    /// </summary>
    [DataField, AutoNetworkedField]
    public bool Enabled;
}
