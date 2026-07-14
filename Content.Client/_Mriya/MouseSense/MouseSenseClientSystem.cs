using Content.Shared.Tag;
using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Client.ResourceManagement;
using Robust.Shared.GameObjects;

namespace Content.Client._Mriya.MouseSense;

public sealed class MouseSenseClientSystem : EntitySystem
{
    [Dependency] private readonly IOverlayManager _overlayMan = default!;
    [Dependency] private readonly IPlayerManager _player = default!;
    [Dependency] private readonly EntityLookupSystem _lookup = default!;
    [Dependency] private readonly TagSystem _tag = default!;
    [Dependency] private readonly IResourceCache _resCache = default!;

    public override void Initialize()
    {
        base.Initialize();
        _overlayMan.AddOverlay(new MouseSenseOverlay(EntityManager, _player, _lookup, _tag, _resCache));
    }

    public override void Shutdown()
    {
        base.Shutdown();
        _overlayMan.RemoveOverlay<MouseSenseOverlay>();
    }
}
