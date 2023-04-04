using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Interfaces;
using OrderManagement.Contracts.Common;
using OrderManagement.Contracts.Input;
using OrderManagement.Contracts.Output;

namespace OrderManagement.Service.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;
        public OrderController(IOrderService orderService) :base()
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("history/{customerId}")]
        public List<Order> GetOrderHistory(int customerId)
        {
            var orders = _orderService.GetOrderHistory(customerId);
            return orders;
        }

        [HttpGet]
        [Route("tracking/{orderId}")]
        public List<TransitLocation> GetOrderTrackingInfo(int orderId)
        {
            var transitLocations = _orderService.GetOrderTrackingInfo(orderId);
            return transitLocations;
        }

        [HttpPost]
        public PlaceOrderResponse PlaceOrder([FromBody] PlaceOrderRequest placeOrderRequest)
        {
            var placeOrderResponse = _orderService.PlaceOrder(placeOrderRequest);
            return placeOrderResponse;
        }
    }
}
