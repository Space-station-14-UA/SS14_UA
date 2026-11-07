using Content.Server.Hands.Systems;
using Content.Server.Mriya.Sponsors;
using Content.Server.Preferences.Managers;
using Content.Server.Storage.EntitySystems;
using Content.Shared.Access.Components;
using Content.Shared.Clothing;
using Content.Shared.Containers.ItemSlots;
using Content.Shared.Hands.Components;
using Content.Shared.Humanoid;
using Content.Shared.Interaction.Components;
using Content.Shared.Inventory;
using Content.Shared.PDA;
using Content.Shared.Preferences;
using Content.Shared.Preferences.Loadouts;
using Content.Shared.Roles;
using Content.Shared.Station;
using Content.Shared.Station.Systems;
using Content.Shared.Storage;
using Robust.Shared.Player;
using System.Linq;

namespace Content.Server.Clothing.Systems;

public sealed partial class OutfitSystem : EntitySystem
{
    [Dependency] private IServerPreferencesManager _preferenceManager = default!;
    [Dependency] private HandsSystem _handSystem = default!;
    [Dependency] private InventorySystem _invSystem = default!;
    [Dependency] private StationSpawningSystem _spawningSystem = default!;
    [Dependency] private ItemSlotsSystem _itemSlotsSystem = default!;
    [Dependency] private StorageSystem _storageSystem = default!;

    [Dependency] private ISponsorManager _sponsorManager = default!;

    public bool SetOutfit(EntityUid target, string gear, Action<EntityUid, EntityUid>? onEquipped = null, bool unremovable = false)
    {
        if (!TryComp(target, out InventoryComponent? inventoryComponent))
            return false;

        if (!ProtoMan.TryIndex<StartingGearPrototype>(gear, out var startingGear))
            return false;

        HumanoidCharacterProfile? profile = null;
        ICommonSession? session = null;
        // Check if we are setting the outfit of a player to respect the preferences
        if (TryComp(target, out ActorComponent? actorComponent))
        {
            session = actorComponent.PlayerSession;
            var userId = actorComponent.PlayerSession.UserId;
            var prefs = _preferenceManager.GetPreferences(userId);
            profile = prefs.SelectedCharacter;
        }

        if (_invSystem.TryGetSlots(target, out var slots))
        {
            foreach (var slot in slots)
            {
                _invSystem.TryUnequip(target, slot.Name, true, true, false, inventoryComponent);
                var gearStr = ((IEquipmentLoadout) startingGear).GetGear(slot.Name);
                if (gearStr == string.Empty)
                    continue;

                var equipmentEntity = Spawn(gearStr, Comp<TransformComponent>(target).Coordinates);
                if (slot.Name == "id" &&
                    TryComp(equipmentEntity, out PdaComponent? pdaComponent) &&
                    TryComp<IdCardComponent>(pdaComponent.ContainedId, out var id))
                {
                    id.FullName = Comp<MetaDataComponent>(target).EntityName;
                }

                _invSystem.TryEquip(target, equipmentEntity, slot.Name, silent: true, force: true, inventory: inventoryComponent);
                if (unremovable)
                    EnsureComp<UnremoveableComponent>(equipmentEntity);

                onEquipped?.Invoke(target, equipmentEntity);
            }
        }

        var coords = Transform(target).Coordinates;
        foreach (var (slotName, storageContainers) in startingGear.Storage)
        {
            if (storageContainers.Count == 0)
                continue;

            if (!_invSystem.TryGetSlotEntity(target, slotName, out var slotEnt))
                continue;

            if (TryComp<StorageComponent>(slotEnt, out var storage))
            {
                foreach (var entProto in storageContainers)
                {
                    var spawnedEntity = SpawnAtPosition(entProto, coords);
                    _storageSystem.Insert(slotEnt.Value, spawnedEntity, out _, user: null, storageComp: storage, playSound: false);
                }
            }
            else if (TryComp<ItemSlotsComponent>(slotEnt, out var itemSlots))
            {
                foreach (var entProto in storageContainers)
                {
                    var spawnedEntity = SpawnAtPosition(entProto, coords);
                    _itemSlotsSystem.TryInsertEmpty((slotEnt.Value, itemSlots), spawnedEntity, null, excludeUserAudio: true);
                }
            }
        }

        if (TryComp(target, out HandsComponent? handsComponent))
        {
            foreach (var prototype in startingGear.Inhand)
            {
                var inhandEntity = Spawn(prototype, coords);
                _handSystem.TryPickup(target, inhandEntity, checkActionBlocker: false, handsComp: handsComponent);
            }
        }

        // See if this starting gear is associated with a job
        var jobs = ProtoMan.EnumeratePrototypes<JobPrototype>();
        foreach (var job in jobs)
        {
            if (job.StartingGear != gear)
                continue;

            var jobProtoId = LoadoutSystem.GetJobPrototype(job.ID);
            if (!ProtoMan.TryIndex<RoleLoadoutPrototype>(jobProtoId, out var jobProto))
                break;

            // Don't require a player, so this works on Urists
            profile ??= TryComp<HumanoidProfileComponent>(target, out var comp)
                ? HumanoidCharacterProfile.DefaultWithSpecies(comp.Species, comp.Sex)
                : new HumanoidCharacterProfile();
            // Try to get the user's existing loadout for the role
            profile.Loadouts.TryGetValue(jobProtoId, out var roleLoadout);

            if (roleLoadout == null)
            {
                // If they don't have a loadout for the role, make a default one
                roleLoadout = new RoleLoadout(jobProtoId);
                roleLoadout.SetDefault(profile, session, ProtoMan);
            }

            var sanitizedLoadout = SanitizeRoleLoadout(target, roleLoadout, jobProto);

            // Equip the target with the job loadout
            _spawningSystem.EquipRoleLoadout(target, sanitizedLoadout, jobProto);
        }

        return true;
    }

    private RoleLoadout SanitizeRoleLoadout(EntityUid entity, RoleLoadout loadout, RoleLoadoutPrototype roleProto)
    {
        var sanitized = new RoleLoadout(loadout.Role)
        {
            EntityName = loadout.EntityName,
            Points = loadout.Points
        };

        foreach (var (groupKey, items) in loadout.SelectedLoadouts)
        {
            // Перевіряємо, чи належить група до цього прототипу
            if (!roleProto.Groups.Contains(groupKey))
                continue;

            var validItems = new List<Loadout>();

            foreach (var item in items)
            {
                if (!ProtoMan.TryIndex(item.Prototype, out var loadoutProto))
                {
                    Log.Error($"Unable to find loadout prototype for {item.Prototype}");
                    continue;
                }

                if (!IsLoadoutAllowed(entity, loadoutProto))
                    continue;

                validItems.Add(item);
            }

            if (validItems.Count > 0)
            {
                sanitized.SelectedLoadouts[groupKey] = validItems;
            }
        }

        return sanitized;
    }

    private bool IsLoadoutAllowed(EntityUid entity, LoadoutPrototype proto)
    {
        if (string.IsNullOrEmpty(proto.SponsorTag))
            return true;

        if (!TryComp<ActorComponent>(entity, out var actor))
        {
            return true;
        }
        return _sponsorManager.HasTag(actor.PlayerSession.UserId, proto.SponsorTag);
    }
}
