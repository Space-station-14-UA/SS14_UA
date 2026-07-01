using Content.Server.Administration;
using Content.Server.Administration.Managers;
using Content.Shared.Actions;
using Content.Shared.Administration;
using Content.Shared._NC.RTS.Components;
using Content.Shared._NC.RTS.Events;
using Content.Shared.Popups;
using Robust.Shared.Player;

namespace Content.Server._NC.RTS.Systems;

/// <summary>
/// Grants and maintains the admin-only RTS toggle action on the currently attached entity.
/// </summary>
public sealed partial class RTSModeSystem : EntitySystem
{
    [Dependency] private IAdminManager _adminManager = default!;
    [Dependency] private SharedActionsSystem _actions = default!;
    [Dependency] private SharedPopupSystem _popup = default!;

    public override void Initialize()
    {
        base.Initialize();

        _adminManager.OnPermsChanged += OnPermsChanged;

        SubscribeLocalEvent<PlayerAttachedEvent>(OnPlayerAttached);
        SubscribeLocalEvent<PlayerDetachedEvent>(OnPlayerDetached);
        SubscribeLocalEvent<RTSModeComponent, ToggleRTSModeActionEvent>(OnToggleAction);
        SubscribeLocalEvent<RTSModeComponent, ComponentShutdown>(OnShutdown);
    }

    public override void Shutdown()
    {
        base.Shutdown();
        _adminManager.OnPermsChanged -= OnPermsChanged;
    }

    private void OnPlayerAttached(PlayerAttachedEvent ev)
    {
        if (ev.Player.AttachedEntity is not { Valid: true } attached)
            return;

        RefreshEntityForSession(ev.Player, attached);
    }

    private void OnPlayerDetached(PlayerDetachedEvent ev)
    {
        if (ev.Entity is not { Valid: true } attached)
            return;

        DisableAndRemove(attached);
    }

    private void OnPermsChanged(AdminPermsChangedEventArgs args)
    {
        if (args.Player.AttachedEntity is not { Valid: true } attached)
            return;

        RefreshEntityForSession(args.Player, attached);
    }

    private void RefreshEntityForSession(ICommonSession session, EntityUid attached)
    {
        if (_adminManager.HasAdminFlag(session, AdminFlags.Admin))
            EnsureMode(attached);
        else
            DisableAndRemove(attached);
    }

    private void EnsureMode(EntityUid uid)
    {
        var comp = EnsureComp<RTSModeComponent>(uid);

        // The action is granted at runtime so only active admins receive it.
        _actions.AddAction(uid, ref comp.ToggleActionEntity, comp.ToggleAction, uid);
        _actions.SetToggled(comp.ToggleActionEntity, comp.Enabled);
        Dirty(uid, comp);
    }

    private void DisableAndRemove(EntityUid uid, RTSModeComponent? comp = null)
    {
        if (!Resolve(uid, ref comp, false))
            return;

        comp.Enabled = false;
        _actions.SetToggled(comp.ToggleActionEntity, false);
        _actions.RemoveAction(uid, comp.ToggleActionEntity);
        RemComp(uid, comp);
    }

    private void OnToggleAction(Entity<RTSModeComponent> ent, ref ToggleRTSModeActionEvent args)
    {
        if (args.Handled)
            return;

        var session = GetSession(ent.Owner);
        if (session == null || !_adminManager.HasAdminFlag(session, AdminFlags.Admin))
            return;

        args.Handled = true;
        args.Toggle = true;

        ent.Comp.Enabled = !ent.Comp.Enabled;
        Dirty(ent);

        var text = ent.Comp.Enabled ? "RTS mode enabled" : "RTS mode disabled";
        _popup.PopupClient(text, ent, ent);
    }

    private void OnShutdown(Entity<RTSModeComponent> ent, ref ComponentShutdown args)
    {
        _actions.RemoveAction(ent.Owner, ent.Comp.ToggleActionEntity);
    }

    private ICommonSession? GetSession(EntityUid uid)
    {
        return CompOrNull<ActorComponent>(uid)?.PlayerSession;
    }
}
