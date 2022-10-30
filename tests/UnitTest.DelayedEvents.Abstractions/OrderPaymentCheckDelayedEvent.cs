using DelayedEvents;

namespace UnitTest.DelayedEvents.Abstractions;

public record OrderPaymentCheckDelayedEvent(Guid OrderId, OrderDetails Details) : DelayedEvent
{
    public void SetName(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Used for test private setter
    /// </summary>
    public string? Name { get; private set; }
}
