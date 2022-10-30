namespace DelayedEvents;

/// <summary>
/// Delayed event
/// NOTE, not all implementations support this property
/// </summary>
public record DelayedEvent
{
    protected DelayedEvent()
    {
        Id          = Guid.NewGuid();
        CreatedTime = DateTime.UtcNow;
    }

    /// <summary>
    /// Message Id
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// The time when the message was created
    /// </summary>
    public DateTime CreatedTime { get; init; }

    /// <summary>
    /// If the message needs to be delayed, the time in seconds that the property saves the delayed message
    /// </summary>
    public uint DelayInSec { get; init; }
}
