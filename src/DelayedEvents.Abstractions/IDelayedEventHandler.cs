namespace DelayedEvents;

/// <summary>
/// The event handler for the event that is raised when a new delayed event is published.
/// </summary>
/// <typeparam name="TIntegrationEvent"></typeparam>
public interface IDelayedEventHandler<in TIntegrationEvent>
    where TIntegrationEvent : DelayedEvent
{
    /// <summary>
    /// The event handler for the event that is raised when a new delayed event is published.
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    Task Handle(TIntegrationEvent e);
}
