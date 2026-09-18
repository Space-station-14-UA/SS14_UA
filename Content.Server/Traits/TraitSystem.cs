using Content.Server._EinsteinEngines.Language;
using Content.Shared.GameTicking;
using Content.Shared.Hands.Components;
using Content.Shared.Hands.EntitySystems;
using Content.Shared.Roles;
using Content.Shared.Traits;
using Content.Shared.Whitelist;
using Robust.Shared.Prototypes;

namespace Content.Server.Traits;

public sealed partial class TraitSystem : EntitySystem
{
    [Dependency] private SharedHandsSystem _sharedHandsSystem = default!;
    [Dependency] private EntityWhitelistSystem _whitelistSystem = default!;
    [Dependency] private LanguageSystem _language = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<PlayerSpawnCompleteEvent>(OnPlayerSpawnComplete);
    }

    // When the player is spawned in, add all trait components selected during character creation
    private void OnPlayerSpawnComplete(PlayerSpawnCompleteEvent args)
    {
        // Check if player's job allows to apply traits
        if (args.JobId == null ||
            !ProtoMan.Resolve<JobPrototype>(args.JobId, out var protoJob) ||
            !protoJob.ApplyTraits)
        {
            return;
        }

        foreach (var traitId in args.Profile.TraitPreferences)
        {
            if (!ProtoMan.TryIndex<TraitPrototype>(traitId, out var traitPrototype))
            {
                Log.Error($"No trait found with ID {traitId}!");
                return;
            }

            if (_whitelistSystem.IsWhitelistFail(traitPrototype.Whitelist, args.Mob) ||
                _whitelistSystem.IsWhitelistPass(traitPrototype.Blacklist, args.Mob))
                continue;

            // Add all components required by the prototype
            if (traitPrototype.Components.Count > 0)
                EntityManager.AddComponents(args.Mob, traitPrototype.Components, false);

            ApplyTraitLanguages(args.Mob, traitPrototype);

            // Add all JobSpecials required by the prototype
            foreach (var special in traitPrototype.Specials)
            {
                special.AfterEquip(args.Mob);
            }

            // Add item required by the trait
            if (traitPrototype.TraitGear == null)
                continue;

            if (!TryComp(args.Mob, out HandsComponent? handsComponent))
                continue;

            var coords = Transform(args.Mob).Coordinates;
            var inhandEntity = Spawn(traitPrototype.TraitGear, coords);
            _sharedHandsSystem.TryPickup(args.Mob,
                inhandEntity,
                checkActionBlocker: false,
                handsComp: handsComponent);
        }
    }

    private void ApplyTraitLanguages(EntityUid mob, TraitPrototype trait)
    {
        if (trait.LanguagesSpoken != null)
        {
            foreach (var language in trait.LanguagesSpoken)
                _language.AddLanguage(mob, language, addSpoken: true, addUnderstood: false);
        }

        if (trait.LanguagesUnderstood != null)
        {
            foreach (var language in trait.LanguagesUnderstood)
                _language.AddLanguage(mob, language, addSpoken: false, addUnderstood: true);
        }

        if (trait.RemoveLanguagesSpoken != null)
        {
            foreach (var language in trait.RemoveLanguagesSpoken)
                _language.RemoveLanguage(mob, language, removeSpoken: true, removeUnderstood: false);
        }

        if (trait.RemoveLanguagesUnderstood != null)
        {
            foreach (var language in trait.RemoveLanguagesUnderstood)
                _language.RemoveLanguage(mob, language, removeSpoken: false, removeUnderstood: true);
        }
    }
}
