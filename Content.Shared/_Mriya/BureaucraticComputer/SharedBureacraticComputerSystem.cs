using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;
using Robust.Shared.Timing;
using Robust.Shared.Toolshed.TypeParsers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Content.Shared._Mriya.BureaucraticComputer;

public abstract class SharedBureacraticComputerSystem : EntitySystem
{
    public static readonly Regex FieldRegex = new(@"\{field=([^|\}]+)(?:\|([^\}]+))?\}", RegexOptions.Compiled);
    [Dependency] protected readonly IGameTiming Timing = default!;
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
