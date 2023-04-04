using OrderManagement.Application.Interfaces;
using OrderManagement.Contracts.Common;
using OrderManagement.Contracts.Input;
using OrderManagement.Contracts.Output;
using OrderManagement.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.Application
{
    internal class OrderService : IOrderService
    {
        private IPublisher _publisher;
        private ICostCalculatorService _costCalculatorService;
        private IOrderRepository _orderRepository;
        private IOrderTrackingRepository _orderTrackingRepository;
        private IProductAvailabilityService _productAvailabilityService;

        public OrderService(IPublisher publisher, ICostCalculatorService costCalculatorService, IOrderRepository orderRepository, IOrderTrackingRepository orderTrackingRepository, IProductAvailabilityService productAvailabilityService)
        {
            _publisher = publisher;
            _costCalculatorService = costCalculatorService;
            _orderRepository = orderRepository;
            _orderTrackingRepository = orderTrackingRepository;
            _productAvailabilityService = productAvailabilityService;
        }

        public List<Order> GetOrderHistory(int customerId)
        {
            // Load orders from the repository
            var orders = _orderRepository.Search(customerId);

            //Convert to output contracts and return
            var contractOrders = orders.Select(order => MapToContract(order));
            return contractOrders.ToList();
        }

        public List<TransitLocation> GetOrderTrackingInfo(int orderId)
        {
            //Load order from the repository
            var domainOrder = _orderRepository.Load(orderId);
            if (domainOrder == null)
                return new List<TransitLocation>();

            //Load the transit locations
            domainOrder.WithOrderTrackingRepository(_orderTrackingRepository);
            domainOrder.LoadTransitLocations();

            //Convert to output contracts and return
            return domainOrder.TransitLocations.Select(location =>
                TransitLocation.Create(
                    location.Name,
                    location.Date,
                    Address.Create(domainOrder.BillingAddress.AddressLine1,
                                    domainOrder.BillingAddress.AddressLine2,
                                    domainOrder.BillingAddress.Country)
                )).ToList();
                
        }

        public PlaceOrderResponse PlaceOrder(PlaceOrderRequest request)
        {
            //Create domain order from the request
            var domainOrder = Domain.Order.Create(
                orderLines:request.Order.OrderLines.Select(line => Domain.OrderLine.Create(
                    product: Domain.Product.Create(
                        stockcode: line.Product.Stockcode,
                        productImageUrl: line.Product.ProductImageUrl,
                        volumetricWeight: line.Product.VolumetricWeight
                    ),
                    quantity: line.Quantity,
                    unitPrice: line.UnitPrice
                    )).ToList(),
                customerId:request.Order.CustomerId,
                billingAddress:Domain.Address.Create(request.Order.BillingAddress.AddressLine1,
                                    request.Order.BillingAddress.AddressLine2,
                                    request.Order.BillingAddress.Country),
                shippingAddress: Domain.Address.Create(request.Order.ShippingAddress.AddressLine1,
                                    request.Order.ShippingAddress.AddressLine2,
                                    request.Order.ShippingAddress.Country),
                promotionCode: request.Order.PromotionCode,
                datePlaced: request.Order.DatePlaced,
                costCalculatorService:_costCalculatorService,
                productAvailabilityService: _productAvailabilityService,
                orderTrackingRepository:_orderTrackingRepository
                );
            
            //Perform domain validation
            if (domainOrder.CanPlaceOrder(request.ExpectedTotalCost, request.ExpectedShippingCost))
            {
                //store the order in the repository
                var orderId = _orderRepository.Store(domainOrder);
                var response = PlaceOrderResponse.Create(true, string.Empty, orderId);
                //publish
                _publisher.Publish(MapToContract(domainOrder, orderId));
                return response;
            }
            else
            {
                var response = PlaceOrderResponse.Create(false, "Order validation failed", null);
                return response;
            }
        }

        private Order MapToContract(Domain.Order order, int? orderId = null)
        {
            return Order.Create(
                orderId: orderId ?? order.OrderId,
                orderLines: order.OrderLines.Select(line => OrderLine.Create(
                    product: Product.Create(
                        stockcode: line.Product.Stockcode,
                        productImageUrl: line.Product.ProductImageUrl,
                        volumetricWeight: line.Product.VolumetricWeight
                    ),
                    quantity: line.Quantity,
                    unitPrice: line.UnitPrice
                    )).ToList(),
                customerId: order.CustomerId,
                totalCost: order.TotalCost,
                shippingCost: order.ShippingCost,
                billingAddress: Address.Create(order.BillingAddress.AddressLine1,
                                    order.BillingAddress.AddressLine2,
                                    order.BillingAddress.Country),
                shippingAddress: Address.Create(order.ShippingAddress.AddressLine1,
                                    order.ShippingAddress.AddressLine2,
                                    order.ShippingAddress.Country),
                promotionCode: order.PromotionCode,
                datePlaced: order.DatePlaced);
        }
    }
}
