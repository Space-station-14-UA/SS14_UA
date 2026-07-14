using Robust.Shared.Timing;

namespace Content.Shared._Mriya.MouseSense;

public abstract class SharedMouseSenseSystem : EntitySystem
{
    [Dependency] protected readonly IGameTiming Timing = default!;
}
