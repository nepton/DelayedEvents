namespace UnitTest.DelayedEvents.Abstractions;

public record OrderDetails(string? OrderNumber)
{
    public string? Description { get; set; }
}
