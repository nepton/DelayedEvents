namespace DelayedEvents;

/// <summary>
/// The event subscriber interface
/// </summary>
public interface IDelayedEventSubscriber
{
    /// <summary>
    /// Adds subscriptions by type name
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="eventHandlerType"></param>
    void Subscribe(Type eventType, Type eventHandlerType);

    /// <summary>
    /// Unsubscribe from an event
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="eventHandlerType"></param>
    void Unsubscribe(Type eventType, Type eventHandlerType);
}
