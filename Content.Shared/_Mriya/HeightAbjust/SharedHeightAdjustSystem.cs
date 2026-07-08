namespace Content.Shared.Mriya.HeightAbjust;

public abstract class SharedHeightAdjustSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<HeightWidthComponent, ComponentInit>(OnInit);
        SubscribeLocalEvent<HeightWidthComponent, AfterAutoHandleStateEvent>(OnAfterAutoHandleStateEventHandler);
    }

    public virtual void OnAfterAutoHandleStateEventHandler(Entity<HeightWidthComponent> ent, ref AfterAutoHandleStateEvent args) { }

    public virtual void OnInit(Entity<HeightWidthComponent> ent, ref ComponentInit args) { }
}
