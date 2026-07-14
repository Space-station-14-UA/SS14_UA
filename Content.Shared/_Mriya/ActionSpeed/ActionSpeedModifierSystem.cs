using Robust.Shared.Prototypes;

namespace Content.Shared._Mriya.ActionSpeed;

public sealed class ActionSpeedModifierSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<ActionSpeedModifierComponent, GetActionSpeedEvent>(OnGetActionSpeed);
    }

    private void OnGetActionSpeed(EntityUid uid, ActionSpeedModifierComponent comp, ref GetActionSpeedEvent args)
    {
        if (comp.Multipliers.TryGetValue(args.Category, out var mult))
            args.Multiplier *= mult;
    }

    public float GetMultiplier(EntityUid uid, ProtoId<ActionSpeedCategoryPrototype> category)
    {
        var ev = new GetActionSpeedEvent(category, 1f);
        RaiseLocalEvent(uid, ref ev);
        return ev.Multiplier;
    }
}
