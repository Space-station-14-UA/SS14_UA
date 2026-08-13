using Content.Shared.Verbs;
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
                _uiSystem.TryToggleUi(ent.Owner, BureaucracyUiKey.Key, user);
            }
        };

        args.Verbs.Add(verb);
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
