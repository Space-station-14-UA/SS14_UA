using Robust.Shared.Audio;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Shared._Mriya.BureaucraticComputer;

[RegisterComponent, AutoGenerateComponentPause]
public sealed partial class BureaucracyComputerComponent : Component
{
    /// <summary>
    /// The id of the paper entity spawned by the print button.
    /// </summary>
    [DataField]
    public EntProtoId PaperId = "Paper";

    /// <summary>
    /// The time at which the console will be able to print a document again.
    /// </summary>
    [DataField(customTypeSerializer: typeof(TimeOffsetSerializer))]
    public TimeSpan NextPrintTime = TimeSpan.Zero;

    /// <summary>
    /// The time between prints.
    /// </summary>
    [DataField]
    public TimeSpan PrintDelay = TimeSpan.FromSeconds(5);

    /// <summary>
    /// The sound made when printing occurs
    /// </summary>
    [DataField]
    public SoundSpecifier PrintSound = new SoundPathSpecifier("/Audio/Machines/printer.ogg");
}
