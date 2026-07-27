using Content.Shared.Storage;
using Content.Shared.Storage.EntitySystems;
using Content.Shared.Weapons.Melee.Components;
using Robust.Shared.Physics.Events;

namespace Content.Shared.Billiards;

public sealed partial class BilliardsSystem : EntitySystem
{
    [Dependency] private SharedStorageSystem _storage = default!;

    [SubscribeLocalEvent]
    private void OnTableCollide(Entity<BilliardsTableComponent> ent, ref StartCollideEvent args)
    {
        if (!args.OurFixtureId.StartsWith("pocket_"))
            return;

        var ballUid = args.OtherEntity;

        if (!HasComp<BilliardsBallComponent>(ballUid))
            return;

        if (!TryComp<StorageComponent>(ent.Owner, out var storage))
            return;

        _storage.Insert(ent.Owner, ballUid, out _, null, storage);
    }

    [SubscribeLocalEvent]
    private void OnAttemptMeleeThrowOnHit(Entity<BilliardsCueComponent> ent, ref AttemptMeleeThrowOnHitEvent args)
    {
        if (!HasComp<BilliardsBallComponent>(args.Target))
            args.Cancelled = true;
    }
}
