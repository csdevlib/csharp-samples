using System;
using RabbitMQ.Client;

namespace EventBus.RabbitMQ.Interfaces;

public interface IRabbitMQPersistentConnection
    : IDisposable
{
    bool IsConnected { get; }

    bool TryConnect();

    IModel CreateModel();
}



