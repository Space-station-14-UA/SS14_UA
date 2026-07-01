using Content.Shared._NC.RTS.Events;
using Robust.Shared.GameStates;
using Robust.Shared.Map;

namespace Content.Shared._NC.RTS.Components;

/// <summary>
/// Marks an NPC that can be manually controlled through the GM RTS layer.
/// The component only stores the replicated override state.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class RTSControllableComponent : Component
{
    /// <summary>
    /// The current world destination for move-like orders.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite), AutoNetworkedField]
    public EntityCoordinates? Destination;

    /// <summary>
    /// The active RTS order. Null returns control to the normal HTN flow.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite), AutoNetworkedField]
    public RTSCommandType? ActiveCommand;

    /// <summary>
    /// The explicitly assigned attack target for focus-fire orders.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite), AutoNetworkedField]
    public EntityUid? TargetEntity;
}
