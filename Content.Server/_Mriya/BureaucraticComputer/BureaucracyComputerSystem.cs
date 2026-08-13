using Content.Server.Station.Systems;
using Content.Shared.Access.Systems;
using Content.Shared.Interaction;
using Content.Shared.Paper;
using Content.Shared._Mriya.BureaucraticComputer;
using Robust.Server.GameObjects;
using Robust.Shared.Audio.Systems;
using Robust.Shared.Player;
using Robust.Shared.Prototypes;
using Robust.Shared.Utility;


namespace Content.Server._Mriya.BureaucraticComputer;

public sealed partial class BureaucracyComputerSystem : SharedBureacraticComputerSystem
{
    [Dependency] private UserInterfaceSystem _uiSystem = default!;
    [Dependency] private IPrototypeManager _prototypeManager = default!;
    [Dependency] private SharedAudioSystem _audio = default!;
    [Dependency] private StationSystem _station = default!;
    [Dependency] private PaperSystem _paperSystem = default!;
    [Dependency] private SharedIdCardSystem _idCardSystem = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<BureaucracyComputerComponent, InteractHandEvent>(OnInteractHand);

        Subs.BuiEvents<BureaucracyComputerComponent>(BureaucracyUiKey.Key, subs =>
        {
            subs.Event<BureaucracyPrintMessage>(OnPrintMessage);
        });
    }

    private void OnInteractHand(EntityUid uid, BureaucracyComputerComponent component, InteractHandEvent args)
    {
        if (!TryComp<ActorComponent>(args.User, out var actor))
            return;

        var station = _station.GetOwningStation(args.User);
        var stationName = station.HasValue ? Name(station.Value) : "";

        var charName = Name(args.User);
        var charJob = "";

        if (_idCardSystem.TryFindIdCard(args.User, out var idCard))
        {
            charJob = idCard.Comp.LocalizedJobTitle ?? idCard.Comp.JobTitle ?? "";
        }

        _uiSystem.OpenUi(uid, BureaucracyUiKey.Key, actor.PlayerSession);

        var state = new BureaucracyAutoFillState(stationName, charName, charJob);
        _uiSystem.SetUiState(uid, BureaucracyUiKey.Key, state);
    }

    private void OnPrintMessage(EntityUid uid, BureaucracyComputerComponent component, BureaucracyPrintMessage args)
    {
        if (Timing.CurTime < component.NextPrintTime)
            return;

        if (_station.GetOwningStation(uid) is not { } station)
            return;

        var paper = Spawn(component.PaperId, Transform(uid).Coordinates);
        component.NextPrintTime = Timing.CurTime + component.PrintDelay;

        // Передаємо args повністю, щоб мати доступ до args.Fields
        SetupDocument(paper, station, args);

        _audio.PlayPvs(component.PrintSound, uid);
    }

    public void SetupDocument(EntityUid uid, EntityUid stationId, BureaucracyPrintMessage args, PaperComponent? paper = null)
    {
        if (!_prototypeManager.TryIndex<BureaucraticDocumentPrototype>(args.PrototypeId, out var prototype))
            return;

        if (!Resolve(uid, ref paper, false))
            return;

        var finalString = FieldRegex.Replace(prototype.Text, match =>
        {
            var fieldId = match.Groups[1].Value.Trim();

            return args.Fields.TryGetValue(fieldId, out var value) ? value : match.Value;
        });

        var msg = new FormattedMessage();
        msg.AddMarkupOrThrow(finalString);
        _paperSystem.SetContent((uid, paper), msg.ToMarkup());
    }
}
