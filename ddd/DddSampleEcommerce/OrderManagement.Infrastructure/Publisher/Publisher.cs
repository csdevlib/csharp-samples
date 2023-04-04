using OrderManagement.Application.Interfaces;

namespace OrderManagement.Infrastructure.Publisher
{
    internal class Publisher : IPublisher
    {
        public void Publish(object o)
        {
           //Perform publishing logic via a message bus
        }
    }
}
