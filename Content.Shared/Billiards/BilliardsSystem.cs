using Content.Shared.Storage.EntitySystems;
using Robust.Shared.Physics.Events;
using Robust.Shared.Audio.Systems;
using Content.Shared.Storage;

namespace Content.Shared.Billiards;

public sealed partial class BilliardsSystem : EntitySystem
{
    [Dependency] private SharedStorageSystem _storage = default!;
    [Dependency] private SharedAudioSystem _audio = default!;

    public override void Initialize()
    {
        base.Initialize();

        // Підписуємося на подію початку зіткнення фікстур
        SubscribeLocalEvent<BilliardsTableComponent, StartCollideEvent>(OnTableCollide);
    }

    private void OnTableCollide(EntityUid uid, BilliardsTableComponent component, ref StartCollideEvent args)
    {
        if (!args.OurFixtureId.StartsWith("pocket_"))
            return;

        var ballUid = args.OtherEntity;

        if (!HasComp<BilliardsBallComponent>(ballUid))
            return;

        if (!TryComp<StorageComponent>(uid, out var storage))
            return;

        _storage.Insert(uid, ballUid, out _, null, storage);
    }
}
