using System.Threading.Tasks;

namespace DelayedEvents;

/// <summary>
/// The event handler for the event that is raised when a new delayed event is published.
/// </summary>
/// <typeparam name="TDelayedEvent"></typeparam>
public interface IDelayedEventHandler<in TDelayedEvent>
    where TDelayedEvent : DelayedEvent
{
    /// <summary>
    /// The event handler for the event that is raised when a new delayed event is published.
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    Task Handle(TDelayedEvent e);
}
