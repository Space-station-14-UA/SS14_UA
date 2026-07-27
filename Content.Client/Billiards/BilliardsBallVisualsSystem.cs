using Content.Shared.Billiards;
using Robust.Client.GameObjects;
using Robust.Shared.Maths;

namespace Content.Client.Billiards;

public sealed partial class BilliardsBallVisualsSystem : VisualizerSystem<BilliardsBallComponent>
{
    [Dependency] private SpriteSystem _spriteSystem = default!;

    protected override void OnAppearanceChange(EntityUid uid, BilliardsBallComponent component, ref AppearanceChangeEvent args)
    {
        base.OnAppearanceChange(uid, component, ref args);

        if (!TryComp<SpriteComponent>(uid, out var sprite))
            return;

        if (AppearanceSystem.TryGetData<Color>(uid, BilliardsVisuals.Color, out var color, args.Component))
        {
            if (_spriteSystem.LayerMapTryGet((uid, sprite), BilliardsVisualLayers.Base, out var baseLayer, false))
            {
                _spriteSystem.LayerSetColor((uid, sprite), baseLayer, color);
            }
        }

        if (AppearanceSystem.TryGetData<bool>(uid, BilliardsVisuals.Stripe, out var hasStripe, args.Component))
        {
            if (_spriteSystem.LayerMapTryGet((uid, sprite), BilliardsVisualLayers.Stripe, out var stripeLayer, false))
            {
                _spriteSystem.LayerSetVisible((uid, sprite), stripeLayer, hasStripe);
            }
        }
    }
}
