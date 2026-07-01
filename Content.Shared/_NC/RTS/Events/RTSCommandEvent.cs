using System.Numerics;
using Robust.Shared.Serialization;

namespace Content.Shared._NC.RTS.Events;

[Serializable, NetSerializable]
public enum RTSCommandType : byte
{
    Move,
    AttackMove,
    AttackTarget,
    HoldPosition,
    Stop
}

/// <summary>
/// Raised by the client to assign a manual RTS order to a set of NPCs.
/// </summary>
[Serializable, NetSerializable]
public sealed class RTSCommandEvent : EntityEventArgs
{
    public List<NetEntity> SelectedNpcs = new();
    public RTSCommandType CommandType;
    public Vector2? TargetPosition;
    public NetEntity? TargetEntity;

    public RTSCommandEvent(
        List<NetEntity> selectedNpcs,
        RTSCommandType commandType,
        Vector2? targetPosition,
        NetEntity? targetEntity)
    {
        SelectedNpcs = selectedNpcs;
        CommandType = commandType;
        TargetPosition = targetPosition;
        TargetEntity = targetEntity;
    }
}
