using System;
using RabbitMQ.Client;

namespace DelayedEvents.RabbitMq;

public interface IRabbitMqPersistentConnection : IDisposable
{
    bool IsConnected { get; }

    bool TryConnect();

    IModel CreateModel();
}
