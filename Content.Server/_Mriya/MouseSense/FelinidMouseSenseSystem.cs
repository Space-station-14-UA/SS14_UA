using Content.Shared._Mriya.MouseSense;
using Content.Shared.Actions;

namespace Content.Server._Mriya.MouseSense;

public sealed class FelinidMouseSenseSystem : EntitySystem
{
    [Dependency] private readonly SharedActionsSystem _actions = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<FelinidMouseSenseComponent, MapInitEvent>(OnMapInit);
        SubscribeLocalEvent<FelinidMouseSenseComponent, ComponentShutdown>(OnShutdown);
    }

    private void OnMapInit(Entity<FelinidMouseSenseComponent> ent, ref MapInitEvent args)
    {
        _actions.AddAction(ent, ref ent.Comp.ActionEntity, ent.Comp.Action, ent);
    }

    private void OnShutdown(Entity<FelinidMouseSenseComponent> ent, ref ComponentShutdown args)
    {
        if (ent.Comp.ActionEntity is { } actionEnt)
            _actions.RemoveAction(actionEnt);
    }
}
