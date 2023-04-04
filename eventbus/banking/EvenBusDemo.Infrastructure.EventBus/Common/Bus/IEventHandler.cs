using EvenBusDemo.Infrastructure.EventBus.Common.Events;
using System.Threading.Tasks;

namespace EvenBusDemo.Infrastructure.EventBus.Common.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent: Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler 
    {

    }
}
