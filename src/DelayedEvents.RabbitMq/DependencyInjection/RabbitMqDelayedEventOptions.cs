#nullable enable
namespace DelayedEvents.RabbitMq.DependencyInjection;

/// <summary>
/// Rabbit mq options for integration events
/// </summary>
public class RabbitMqDelayedEventOptions
{
    /// <summary>
    /// Rabbitmq 主机名
    /// </summary>
    public string? Host { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// 在 RabbitMq 中的 broker name
    /// </summary>
    public string? BrokerName { get; set; }

    /// <summary>
    /// 消息发送重试次数
    /// </summary>
    public int RetryCount { get; set; } = 5;

    /// <summary>
    /// 消息订阅的客户端名
    /// </summary>
    public string? ClientName { get; set; }
}
