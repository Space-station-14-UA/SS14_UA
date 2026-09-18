namespace Content.Shared._EinsteinEngines.Language.Events;

/// <summary>
/// Raised on a listener to cancel hearing a language message (e.g. blindness for sign language).
/// </summary>
[ByRefEvent]
public record struct ChatMessageOverrideInRange(bool RequiresHearing = false, bool RequiresSight = false, bool Cancelled = false)
{
    public void Cancel()
    {
        Cancelled = true;
    }
}
