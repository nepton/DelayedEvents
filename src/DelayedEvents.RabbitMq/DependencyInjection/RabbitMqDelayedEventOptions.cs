#nullable enable
namespace DelayedEvents.RabbitMq.DependencyInjection;

/// <summary>
/// Rabbit mq options for delayed events
/// </summary>
public class RabbitMqDelayedEventOptions
{
    /// <summary>
    /// Rabbitmq hostName
    /// </summary>
    public string? Host { get; set; }

    /// <summary>
    /// The user name used to login rabbitmq
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// password used to login rabbitmq
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// broker name in RabbitMq
    /// </summary>
    public string? BrokerName { get; set; }

    /// <summary>
    /// Number of message sending retries
    /// </summary>
    public int RetryCount { get; set; } = 5;

    /// <summary>
    /// The name of the client to which the message is subscribed
    /// </summary>
    public string? ClientName { get; set; }
}
