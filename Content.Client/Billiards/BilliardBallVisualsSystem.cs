using Content.Shared.Billiards;
using Robust.Client.GameObjects;
using Robust.Shared.Maths;

namespace Content.Client.Billiards;

public sealed partial class BilliardBallVisualsSystem : VisualizerSystem<BilliardBallComponent>
{
    [Dependency] private SpriteSystem _spriteSystem = default!;

    protected override void OnAppearanceChange(EntityUid uid, BilliardBallComponent component, ref AppearanceChangeEvent args)
    {
        base.OnAppearanceChange(uid, component, ref args);

        if (!TryComp<SpriteComponent>(uid, out var sprite))
            return;

        if (AppearanceSystem.TryGetData<Color>(uid, BilliardVisuals.Color, out var color, args.Component))
        {
            if (_spriteSystem.LayerMapTryGet((uid, sprite), BilliardVisualLayers.Base, out var baseLayer, false))
            {
                _spriteSystem.LayerSetColor((uid, sprite), baseLayer, color);
            }
        }

        if (AppearanceSystem.TryGetData<bool>(uid, BilliardVisuals.Stripe, out var hasStripe, args.Component))
        {
            if (_spriteSystem.LayerMapTryGet((uid, sprite), BilliardVisualLayers.Stripe, out var stripeLayer, false))
            {
                _spriteSystem.LayerSetVisible((uid, sprite), stripeLayer, hasStripe);
            }
        }
    }
}
