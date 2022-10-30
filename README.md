<<<<<<< HEAD
﻿# DelayedEvents
[![Build status](https://ci.appveyor.com/api/projects/status/rdai4o302paf94fe?svg=true)](https://ci.appveyor.com/project/nepton/DelayedEvents)
[![CodeQL](https://github.com/nepton/DelayedEvents/actions/workflows/codeql.yml/badge.svg)](https://github.com/nepton/DelayedEvents/actions/workflows/codeql.yml)
![GitHub issues](https://img.shields.io/github/issues/nepton/DelayedEvents.svg)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/nepton/DelayedEvents/blob/master/LICENSE)

DelayedEvents is a library that provides a simple way to implement delayed message.
For example: you can use it to implement when order is not paid in 15 minutes, cancel the order.

## Nuget packages

| Name                       | Version                                                                                                                               | Downloads                                                                                                                              |
|----------------------------|---------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
| DelayedEvents.Abstractions | [![nuget](https://img.shields.io/nuget/v/DelayedEvents.Abstractions.svg)](https://www.nuget.org/packages/DelayedEvents.Abstractions/) | [![stats](https://img.shields.io/nuget/dt/DelayedEvents.Abstractions.svg)](https://www.nuget.org/packages/DelayedEvents.Abstractions/) |
| DelayedEvents.RabbitMq     | [![nuget](https://img.shields.io/nuget/v/DelayedEvents.RabbitMq.svg)](https://www.nuget.org/packages/DelayedEvents.RabbitMq/)         | [![stats](https://img.shields.io/nuget/dt/DelayedEvents.RabbitMq.svg)](https://www.nuget.org/packages/DelayedEvents.RabbitMq/)         |
=======
﻿# IntegrationEvents

[![Build status](https://ci.appveyor.com/api/projects/status/rdai4o302paf94fe?svg=true)](https://ci.appveyor.com/project/nepton/integrationevents)
[![CodeQL](https://github.com/nepton/IntegrationEvents/actions/workflows/codeql.yml/badge.svg)](https://github.com/nepton/IntegrationEvents/actions/workflows/codeql.yml)
![GitHub issues](https://img.shields.io/github/issues/nepton/IntegrationEvents.svg)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/nepton/IntegrationEvents/blob/master/LICENSE)

IntegrationEvents is a library that provides a simple way to implement
the [Integration Events](https://microservices.io/patterns/data/transactional-outbox.html) pattern.

## Nuget packages

| Name                           | Version                                                                                                                                       | Downloads                                                                                                                                      |
|--------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------|
| IntegrationEvents.Abstractions | [![nuget](https://img.shields.io/nuget/v/IntegrationEvents.Abstractions.svg)](https://www.nuget.org/packages/IntegrationEvents.Abstractions/) | [![stats](https://img.shields.io/nuget/dt/IntegrationEvents.Abstractions.svg)](https://www.nuget.org/packages/IntegrationEvents.Abstractions/) |
| IntegrationEvents.RabbitMq     | [![nuget](https://img.shields.io/nuget/v/IntegrationEvents.RabbitMq.svg)](https://www.nuget.org/packages/IntegrationEvents.RabbitMq/)         | [![stats](https://img.shields.io/nuget/dt/IntegrationEvents.RabbitMq.svg)](https://www.nuget.org/packages/IntegrationEvents.RabbitMq/)         |
>>>>>>> origin/master

## Installation

Add following nuget reference in business project:

```
<<<<<<< HEAD
PM> Install-Package DelayedEvents.Abstractions
=======
PM> Install-Package IntegrationEvents
>>>>>>> origin/master
```

And add following nuget reference in integration project:

``` 
<<<<<<< HEAD
PM> Install-Package DelayedEvents.RabbitMq
```

Make sure the plugins rabbitmq_delayed_message_exchange are enabled.
https://blog.rabbitmq.com/posts/2015/04/scheduling-messages-with-rabbitmq/

## How to use

First of all, you need to create a class that derived from the `DelayedEvent` class.

```csharp
public class OrderPaymentCheckDelayedEvent : DelayedEvent
{
    public OrderPaymentCheckDelayedEvent(Guid orderId)
    {
        OrderId = orderId;
        DelayInSec = 15 * 60;   // Make 15 minutes delay   
    }

    public Guid OrderId { get; }
}
```

Then, you need to create a class that derived from the `DelayedEventHandler` class.

```csharp
public class OrderPaymentCheckDelayedEventHandler : DelayedEventHandler<OrderPaymentCheckDelayedEvent>
{
    private readonly IOrderService _orderService;

    public OrderPaymentCheckDelayedEventHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public override async Task Handle(OrderPaymentCheckDelayedEvent e)
    {
        // We will cancel the order if it is not paid in 15 minutes
        await _orderService.CancelOrderIfNotPaidAsync(e.OrderId);
=======
PM> Install-Package IntegrationEvents.RabbitMq
```

## How to use

First of all, you need to create a class that derived from the `IntegrationEvent` class.

```csharp
public class OrderCreatedIntegrationEvent : IntegrationEvent
{
    public OrderCreatedIntegrationEvent(Guid orderId, string orderName)
    {
        OrderId = orderId;
        OrderName = orderName;
    }

    public Guid OrderId { get; }

    public string OrderName { get; }
}
```

Then, you need to create a class that derived from the `IntegrationEventHandler` class.

```csharp
public class OrderCreatedIntegrationEventHandler : IIntegrationEventHandler<OrderCreatedIntegrationEvent>
{
    public override Task Handle(OrderCreatedIntegrationEvent @event)
    {
>>>>>>> origin/master
    }
}
```

<<<<<<< HEAD
Finally, you need to register the `DelayedEventHandler` in the `Startup.cs` file.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDelayedEvents()
        .AddRabbitMq(options =>
        {
            options.HostName = "localhost";
            options.UserName = "guest";
            options.Password = "guest";
        })
        .AddDelayedEventHandler<OrderPaymentCheckDelayedEventHandler>();
}
```

Ok! Now you can publish the `DelayedEvent` class in the business project.

```csharp
public class OrderService : IOrderService
{
    private readonly IDelayedEventPublisher _delayedEventPublisher;

    public OrderService(IDelayedEventPublisher delayedEventPublisher)
    {
        _delayedEventPublisher = delayedEventPublisher;
    }

    public async Task CreateOrderAsync(Order order)
    {
        // Create order

        // Publish the delayed event
        await _delayedEventPublisher.PublishAsync(new OrderPaymentCheckDelayedEvent(order.Id));
    }
}
```
=======
Finally, you need to register the `IntegrationEventHandler` class in the `IServiceCollection`.
```csharp
services.AddIntegrationEventBus(builder =>
{
    builder.AddIntegrationEventsWithRabbitMq();
    builder.AddIntegrationEventHandler<OrderCreatedIntegrationEventHandler>();
});
```

Ok! Now you can publish the `IntegrationEvent` class in the business project.

```csharp
var integrationEventBus = serviceProvider.GetRequiredService<IIntegrationEventBus>();
await integrationEventBus.PublishAsync(new OrderCreatedIntegrationEvent(Guid.NewGuid(), "OrderName"));
``` 
>>>>>>> origin/master

## Final
Leave a comment on GitHub if you have any questions or suggestions.

Turn on the star if you like this project.

## License

This project is licensed under the MIT License
