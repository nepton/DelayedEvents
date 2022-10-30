namespace DelayedEvents;

public static class DelayedEventSubscriptionExtensions
{
    /// <summary>
    /// Subscribe to the event
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    /// <typeparam name="TEventHandler"></typeparam>
    public static void Subscribe<TEvent, TEventHandler>(this IDelayedEventBus source) where TEvent : DelayedEvent where TEventHandler : IDelayedEventHandler<TEvent>
    {
        source.Subscribe(typeof(TEvent), typeof(TEventHandler));
    }

    /// <summary>
    /// Simplify the subscription process
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    public static void Subscribe<TEvent>(this IDelayedEventBus source) where TEvent : DelayedEvent
    {
        source.Subscribe(typeof(TEvent), typeof(IDelayedEventHandler<>).MakeGenericType(typeof(TEvent)));
    }

    /// <summary>
    /// Unsubscribe from the event
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    /// <typeparam name="TEventHandler"></typeparam>
    public static void Unsubscribe<TEvent, TEventHandler>(this IDelayedEventBus source) where TEventHandler : IDelayedEventHandler<TEvent> where TEvent : DelayedEvent
    {
        source.Unsubscribe(typeof(TEvent), typeof(TEventHandler));
    }
}
