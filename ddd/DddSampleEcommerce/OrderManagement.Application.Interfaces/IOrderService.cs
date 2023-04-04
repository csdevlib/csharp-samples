using OrderManagement.Contracts.Common;
using OrderManagement.Contracts.Input;
using OrderManagement.Contracts.Output;
using System.Collections.Generic;

namespace OrderManagement.Application.Interfaces
{
    public interface IOrderService
    {
        PlaceOrderResponse PlaceOrder(PlaceOrderRequest request);
        List<Order> GetOrderHistory(int customerId);
        List<TransitLocation> GetOrderTrackingInfo(int orderId);
    }
}
