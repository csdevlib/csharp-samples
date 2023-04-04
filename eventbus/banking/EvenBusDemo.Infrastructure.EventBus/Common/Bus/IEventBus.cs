using EvenBusDemo.Infrastructure.EventBus.Common.Commands;
using EvenBusDemo.Infrastructure.EventBus.Common.Events;
using System.Threading.Tasks;

namespace EvenBusDemo.Infrastructure.EventBus.Common.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, THandler>() where T : Event where THandler : IEventHandler<T>;
    }
}
