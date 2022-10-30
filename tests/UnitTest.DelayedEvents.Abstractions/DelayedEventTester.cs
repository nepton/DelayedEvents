using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace UnitTest.DelayedEvents.Abstractions;

public class DelayedEventTester
{
    [Fact]
    public void TestNewtonsoftSerialization()
    {
        // arrange
        var expected = new OrderPaymentCheckDelayedEvent(Guid.NewGuid(), new OrderDetails(Guid.NewGuid().ToString()))
        {
            DelayInSec = 10,
        };
        var serialized = JsonConvert.SerializeObject(expected);

        // act
        var actual = JsonConvert.DeserializeObject<OrderPaymentCheckDelayedEvent>(serialized);

        // assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestSystemJsonSerialization()
    {
        // arrange
        var expected = new OrderPaymentCheckDelayedEvent(Guid.NewGuid(), new OrderDetails(Guid.NewGuid().ToString()))
        {
            DelayInSec = 10,
        };
        var serialized = JsonSerializer.Serialize(expected);

        // act
        var actual = JsonSerializer.Deserialize<OrderPaymentCheckDelayedEvent>(serialized);

        // assert
        Assert.Equal(expected, actual);
    }
}
