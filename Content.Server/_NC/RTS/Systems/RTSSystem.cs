using System.Numerics;
using Content.Server.Administration.Managers;
using Content.Server.NPC;
using Content.Server.NPC.HTN;
using Content.Server.NPC.Systems;
using Content.Shared.Administration;
using Content.Shared._NC.RTS.Components;
using Content.Shared._NC.RTS.Events;
using Robust.Shared.Map;

namespace Content.Server._NC.RTS.Systems;

/// <summary>
/// Accepts RTS commands from admin clients and writes them into replicated
/// component state so the server-side command executor can take over the NPC.
/// </summary>
public sealed partial class RTSSystem : EntitySystem
{
    private const string ManualCommandKey = "InManualCommand";

    [Dependency] private IAdminManager _adminManager = default!;
    [Dependency] private HTNSystem _htn = default!;
    [Dependency] private NPCSteeringSystem _steering = default!;
    [Dependency] private SharedTransformSystem _transform = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeNetworkEvent<RTSCommandEvent>(OnCommandReceived);
    }

    private void OnCommandReceived(RTSCommandEvent ev, EntitySessionEventArgs args)
    {
        if (!_adminManager.HasAdminFlag(args.SenderSession, AdminFlags.Admin))
            return;

        foreach (var netEntity in ev.SelectedNpcs)
        {
            var uid = GetEntity(netEntity);

            if (!Exists(uid) || !TryComp<RTSControllableComponent>(uid, out var rts))
                continue;

            rts.Destination = null;
            rts.TargetEntity = null;
            rts.ActiveCommand = null;

            switch (ev.CommandType)
            {
                case RTSCommandType.Move:
                case RTSCommandType.AttackMove:
                {
                    var coords = ResolveTargetCoordinates(uid, ev);
                    if (coords == null)
                        continue;

                    rts.Destination = coords;
                    rts.ActiveCommand = ev.CommandType;
                    break;
                }

                case RTSCommandType.AttackTarget:
                {
                    if (ev.TargetEntity == null)
                        break;

                    var targetUid = GetEntity(ev.TargetEntity.Value);
                    if (!Exists(targetUid))
                        break;

                    rts.TargetEntity = targetUid;
                    rts.ActiveCommand = RTSCommandType.AttackTarget;
                    break;
                }

                case RTSCommandType.HoldPosition:
                    rts.ActiveCommand = RTSCommandType.HoldPosition;
                    break;

                case RTSCommandType.Stop:
                    _steering.Unregister(uid);
                    break;
            }

            Dirty(uid, rts);

            if (!TryComp<HTNComponent>(uid, out var htn))
                continue;

            if (rts.ActiveCommand != null)
                htn.Blackboard.SetValue(ManualCommandKey, true);
            else
                htn.Blackboard.Remove<object>(ManualCommandKey);

            // Shut the running plan down immediately so the manual order wins now,
            // not after the next natural HTN transition.
            if (htn.Plan != null)
                _htn.ShutdownPlan(htn);

            _htn.Replan(htn);
        }
    }

    /// <summary>
    /// Resolves click target data into coordinates in the controlled NPC's parent space.
    /// </summary>
    private EntityCoordinates? ResolveTargetCoordinates(EntityUid uid, RTSCommandEvent ev)
    {
        if (ev.TargetEntity != null)
        {
            var targetUid = GetEntity(ev.TargetEntity.Value);
            if (Exists(targetUid))
                return Transform(targetUid).Coordinates;
        }

        if (ev.TargetPosition == null)
            return null;

        var xform = Transform(uid);
        var parentXform = Transform(xform.ParentUid);
        var localPos = Vector2.Transform(ev.TargetPosition.Value, _transform.GetInvWorldMatrix(parentXform));
        return new EntityCoordinates(xform.ParentUid, localPos);
    }
}
