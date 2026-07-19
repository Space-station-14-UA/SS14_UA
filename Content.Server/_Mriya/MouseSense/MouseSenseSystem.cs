using Content.Shared._Mriya.MouseSense;
using Content.Shared.Popups;

namespace Content.Server._Mriya.MouseSense;

public sealed class MouseSenseSystem : SharedMouseSenseSystem
{
    [Dependency] private readonly SharedPopupSystem _popup = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<MouseSenseActionEvent>(OnAction);
    }

    private void OnAction(MouseSenseActionEvent args)
    {
        var uid = args.Performer;
        var comp = EnsureComp<MouseSenseComponent>(uid);
        comp.EndTime = Timing.CurTime + comp.Duration;
        Dirty(uid, comp);

        _popup.PopupEntity(Loc.GetString("mouse-sense-popup"), uid, uid);
        args.Handled = true;
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var query = EntityQueryEnumerator<MouseSenseComponent>();
        while (query.MoveNext(out var uid, out var comp))
        {
            if (Timing.CurTime >= comp.EndTime)
                RemComp<MouseSenseComponent>(uid);
        }
    }
}
