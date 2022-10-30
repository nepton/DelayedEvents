using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace DelayedEvents.RabbitMq.DependencyInjection;

/// <summary>
/// Configure to use RabbitMQ as the event bus
/// </summary>
public static class RabbitMqDelayedEventsServiceExtensions
{
    /// <summary>
    /// Configure to use RabbitMQ as the event bus
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddDelayedEventsUsingRabbitMq(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.Get<RabbitMqDelayedEventOptions>();
        services.AddSingleton<IRabbitMqPersistentConnection>(sp =>
        {
            var logger = sp.GetRequiredService<ILogger<RabbitMqPersistentConnection>>();
            var factory = new ConnectionFactory()
            {
                HostName               = options.Host,
                DispatchConsumersAsync = true
            };

            if (!string.IsNullOrEmpty(options.Username)) factory.UserName = options.Username;
            if (!string.IsNullOrEmpty(options.Password)) factory.Password = options.Password;

            return new RabbitMqPersistentConnection(factory, logger, options.RetryCount);
        });

        services.AddSingleton<IDelayedEventBus, RabbitMqDelayedEventBus>(sp =>
        {
            var brokerName                   = options.BrokerName ?? throw new InvalidDataException("Broker name in rabbitmq is Required");
            var subscriptionClientName       = options.ClientName ?? throw new InvalidDataException("Client name in rabbitmq is Required");
            var rabbitMqPersistentConnection = sp.GetRequiredService<IRabbitMqPersistentConnection>();
            var iLifetimeScope               = sp.GetRequiredService<IServiceProvider>();
            var logger                       = sp.GetRequiredService<ILogger<RabbitMqDelayedEventBus>>();
            var eventBusSubscriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

            return new RabbitMqDelayedEventBus(rabbitMqPersistentConnection,
                logger,
                iLifetimeScope,
                eventBusSubscriptionsManager,
                brokerName,
                subscriptionClientName,
                options.RetryCount);
        });

        services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

        return services;
    }
}
