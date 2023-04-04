using Newtonsoft.Json;
using OrderManagement.Contracts.Common;

namespace OrderManagement.Contracts.Output
{
    public class OrderPlacedEvent
    {
        Order Order { get; }

        [JsonConstructor]
        private OrderPlacedEvent(Order order)
        {
            Order = order;
        }

        public static OrderPlacedEvent Create(Order order)
        {
            return new OrderPlacedEvent(order);
        }
    }
}
