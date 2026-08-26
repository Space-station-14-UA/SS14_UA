using Content.Shared.Access.Systems;
using Content.Shared.Interaction;
using Content.Shared.Station;
using Content.Shared.UserInterface;
using Content.Shared.Verbs;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;
using Robust.Shared.Timing;
using Robust.Shared.Utility;
using System.Text.RegularExpressions;

namespace Content.Shared._Mriya.BureaucraticComputer;

public abstract partial class SharedBureacraticComputerSystem : EntitySystem
{
    public static readonly Regex FieldRegex = new(@"\{field=([^|\}]+)(?:\|([^\}]+))?\}", RegexOptions.Compiled);
    [Dependency] protected IGameTiming Timing = default!;
    [Dependency] protected ILocalizationManager Loc = default!;
    [Dependency] private SharedUserInterfaceSystem _uiSystem = default!;
    [Dependency] private SharedIdCardSystem _idCardSystem = default!;
    [Dependency] private SharedStationSystem _station = default!;

    [SubscribeLocalEvent]
    private void AfterOpenUI(Entity<ActivatableUIComponent> ent, ref AfterActivatableUIOpenEvent args)
    {
        if (ent.Comp.Key is not BureaucracyUiKey.Key)
            return;

        SetupAutoFill(ent.Owner, args.User);
    }

    [SubscribeLocalEvent]
    private void OnGetVerbs(Entity<BureaucracyComputerComponent> ent, ref GetVerbsEvent<ActivationVerb> args)
    {
        if (!args.CanAccess || !args.CanInteract)
            return;

        if (!_uiSystem.HasUi(ent.Owner, BureaucracyUiKey.Key))
            return;

        var user = args.User;

        var verb = new ActivationVerb
        {
            Text = Loc.GetString("bureaucracy-computer-window-title"),
            Icon = new SpriteSpecifier.Texture(new("/Textures/Interface/VerbIcons/settings.svg.192dpi.png")),
            Act = () =>
            {
                SetupAutoFill(ent.Owner, user);
            }
        };

        args.Verbs.Add(verb);
    }

    private void SetupAutoFill(EntityUid computer, EntityUid user)
    {
        if (!TryComp<ActorComponent>(user, out var actor))
            return;

        var station = _station.GetOwningStation(user);
        var stationName = station.HasValue ? Name(station.Value) : "";

        var charName = Name(user);
        var charJob = "";

        if (_idCardSystem.TryFindIdCard(user, out var idCard))
        {
            charJob = idCard.Comp.LocalizedJobTitle ?? idCard.Comp.JobTitle ?? "";
        }

        _uiSystem.OpenUi(computer, BureaucracyUiKey.Key, actor.PlayerSession);

        var state = new BureaucracyAutoFillState(stationName, charName, charJob);
        _uiSystem.SetUiState(computer, BureaucracyUiKey.Key, state);
    }
}

[Serializable, NetSerializable]
public enum BureaucracyUiKey : byte
{
    Key
}

[Serializable, NetSerializable]
public sealed class BureaucracyPrintMessage : BoundUserInterfaceMessage
{
    public readonly ProtoId<BureaucraticDocumentPrototype> PrototypeId;
    public readonly Dictionary<string, string> Fields;

    public BureaucracyPrintMessage(ProtoId<BureaucraticDocumentPrototype> prototypeId, Dictionary<string, string> fields)
    {
        PrototypeId = prototypeId;
        Fields = fields;
    }
}

[Serializable, NetSerializable]
public sealed class BureaucracyAutoFillState : BoundUserInterfaceState
{
    public readonly string StationName;
    public readonly string CharacterName;
    public readonly string CharacterJob;

    public BureaucracyAutoFillState(string stationName, string characterName, string characterJob)
    {
        StationName = stationName;
        CharacterName = characterName;
        CharacterJob = characterJob;
    }
}
