using RabbitMQ.Client;

namespace SkillMap.EventBus.RabbitMQ.Interfaces;

public interface IRabbitMQPersistentConnection : IDisposable
{
    bool IsConnected { get; }

    bool TryConnect();

    IModel CreateModel();
}
