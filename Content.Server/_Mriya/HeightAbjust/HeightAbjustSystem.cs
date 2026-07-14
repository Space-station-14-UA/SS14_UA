using Content.Shared.Body;
using Content.Shared.CCVar;
using Content.Shared.Movement.Components;
using Content.Shared.Movement.Systems;
using Content.Shared.Mriya.HeightAbjust;
using Robust.Shared.Configuration;
using Robust.Shared.Network;
using Robust.Shared.Physics;
using Robust.Shared.Physics.Systems;
using System.Numerics;
public sealed partial class HeightAbjustSystem : SharedHeightAdjustSystem
{
    [Dependency] private SharedPhysicsSystem _physics = default!;
    [Dependency] private SharedContentEyeSystem _eye = default!;
    [Dependency] private IConfigurationManager _config = default!;

    public override void OnAfterAutoHandleStateEventHandler(Entity<HeightWidthComponent> ent, ref AfterAutoHandleStateEvent args)
    {
        base.OnAfterAutoHandleStateEventHandler(ent, ref args);
        var width = ent.Comp.Width;
        var height = ent.Comp.Height;
        var scale = new Vector2(width, height);
        SetScale(ent.Owner, scale);
    }

    public override void OnInit(Entity<HeightWidthComponent> ent, ref ComponentInit args)
    {
        base.OnInit(ent, ref args);
        var width = ent.Comp.Width;
        var height = ent.Comp.Height;
        var scale = new Vector2(width, height);
        SetScale(ent.Owner, scale);
    }

    /// <summary>
    ///     Changes the density of fixtures and zoom of eyes based on a provided Vector2 scale
    /// </summary>
    /// <param name="uid">The entity to modify values for</param>
    /// <param name="scale">The scale to multiply values by</param>
    /// <returns>True if all operations succeeded</returns>
    public void SetScale(EntityUid uid, Vector2 scale)
    {
        var avg = (scale.X + scale.Y) / 2;

        if (_config.GetCVar(CCVars.HeightAdjustModifiesZoom) && TryComp<ContentEyeComponent>(uid, out var eye))
            _eye.SetMaxZoom(uid, eye.MaxZoom * avg);

        if (_config.GetCVar(CCVars.HeightAdjustModifiesHitbox) && TryComp<FixturesComponent>(uid, out var fixtures))
            foreach (var fixture in fixtures.Fixtures)
                _physics.SetRadius(uid, fixture.Key, fixture.Value, fixture.Value.Shape, MathF.MinMagnitude(fixture.Value.Shape.Radius * avg, 0.49f));
    }
}
