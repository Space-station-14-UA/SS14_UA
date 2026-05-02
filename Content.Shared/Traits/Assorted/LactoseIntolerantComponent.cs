using Robust.Shared.GameStates;

namespace Content.Shared.Traits.Assorted;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class LactoseIntolerantComponent : Component
{
    /// <summary>
    /// Затримка перед блювотою після вживання реагенту
    /// </summary>
    [DataField, AutoNetworkedField]
    public TimeSpan VomitDelay = TimeSpan.FromSeconds(5);

    [DataField, AutoNetworkedField]
    public TimeSpan VomitCooldown = TimeSpan.FromSeconds(10);
    /// <summary>
    /// Ймовірність блювання
    /// </summary>
    [DataField, AutoNetworkedField]
    public float VomitChance = 0.8f;

    [DataField, AutoNetworkedField]
    public TimeSpan? LastVomitTime;

    [DataField, AutoNetworkedField]
    public bool HasVomitedThisSession;
}
