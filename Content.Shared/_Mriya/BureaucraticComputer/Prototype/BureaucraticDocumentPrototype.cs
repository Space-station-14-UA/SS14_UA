using Robust.Shared.Prototypes;

namespace Content.Shared._Mriya.BureaucraticComputer;

[Prototype]
public sealed partial class BureaucraticDocumentPrototype : IPrototype
{
    [IdDataField]
    public string ID { get; private set; } = default!;

    [DataField]
    public string Name { get; private set; } = string.Empty;

    [DataField(required: true)]
    public string Text { get; private set; } = string.Empty;
}
