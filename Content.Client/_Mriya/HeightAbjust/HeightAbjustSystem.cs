using Content.Shared.Body;
using Content.Shared.Mriya.HeightAbjust;
using Robust.Client.GameObjects;
using System.Numerics;

namespace Content.Client.Mriya.HeightAbjust;

public sealed partial class HeightAbjustSystem : SharedHeightAdjustSystem
{
    [Dependency] private readonly SpriteSystem _sprite = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<HeightWidthComponent, ApplyHeightWidth>(OnApperanceEventHandler);
    }

    private void OnApperanceEventHandler(Entity<HeightWidthComponent> ent, ref ApplyHeightWidth args)
    {
        ChangeHeightWidth(ent);
    }

    public override void OnAfterAutoHandleStateEventHandler(Entity<HeightWidthComponent> ent, ref AfterAutoHandleStateEvent args)
    {
        base.OnAfterAutoHandleStateEventHandler(ent, ref args);
        ChangeHeightWidth(ent);
    }

    public override void OnInit(Entity<HeightWidthComponent> ent, ref ComponentInit args)
    {
        base.OnInit(ent, ref args);
        ChangeHeightWidth(ent);
    }

    private void ChangeHeightWidth(Entity<HeightWidthComponent> ent)
    {
        var width = ent.Comp.Width;
        var height = ent.Comp.Height;
        var scale = new Vector2(width, height);
        _sprite.SetScale(ent.Owner, scale);
    }
}
