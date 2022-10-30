namespace DelayedEvents;

/// <summary>
/// Interface to the event bus
/// </summary>
public interface IDelayedEventPublisher
{
    /// <summary>
    /// Publishes the specified event.
    /// </summary>
    /// <param name="e"></param>
    void Publish(DelayedEvent e);
}
