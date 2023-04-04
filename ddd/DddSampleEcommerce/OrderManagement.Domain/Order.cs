using OrderManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.Domain
{
    public class Order
    {
        private ICostCalculatorService _costCalculatorService;
        private IOrderTrackingRepository _orderTrackingRepository;
        private IProductAvailabilityService _productAvailabilityService;

        public int OrderId { get; }
        public List<OrderLine> OrderLines { get; }
        public int CustomerId { get; }
        public decimal ShippingCost { get; private set; }
        public decimal TotalCost { get; private set; }
        public Address BillingAddress { get; }
        public Address ShippingAddress { get; }
        public string PromotionCode { get; }
        public DateTime DatePlaced { get; }
        public List<TransitLocation> TransitLocations { get; private set; }

        private Order(int orderId,
                      List<OrderLine> orderLines,
                      int customerId,
                      decimal totalCost,
                      decimal shippingCost,
                      Address billingAddress,
                      Address shippingAddress,
                      string promotionCode,
                      DateTime datePlaced,
                      List<TransitLocation> transitLocations,
                      ICostCalculatorService costCalculatorService,
                      IProductAvailabilityService productAvailabilityService,
                      IOrderTrackingRepository orderTrackingRepository)
        {
            OrderId = orderId;
            OrderLines = orderLines;
            CustomerId = customerId;
            TotalCost = totalCost;
            ShippingCost = shippingCost;
            PromotionCode = promotionCode;
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
            DatePlaced = datePlaced;
            TransitLocations = transitLocations;
            _costCalculatorService = costCalculatorService;
            _orderTrackingRepository = orderTrackingRepository;
            _productAvailabilityService = productAvailabilityService;
        }

        public static Order Create(List<OrderLine> orderLines,
                                   int customerId,
                                   Address billingAddress,
                                   Address shippingAddress,
                                   string promotionCode,
                                   DateTime datePlaced,
                                   ICostCalculatorService costCalculatorService,
                                   IProductAvailabilityService productAvailabilityService,
                                   IOrderTrackingRepository orderTrackingRepository)
        {
            return new Order(-1, orderLines, customerId, -1, -1, billingAddress, shippingAddress, promotionCode, datePlaced, null, costCalculatorService, productAvailabilityService, orderTrackingRepository);
        }

        public static Order Create(int orderId,
                                   List<OrderLine> orderLines,
                                   int customerId,
                                   decimal totalCost, 
                                   decimal shippingCost,
                                   Address billingAddress,
                                   Address shippingAddress,
                                   string promotionCode,
                                   DateTime datePlaced)
        {
            return new Order(orderId, orderLines, customerId, totalCost, shippingCost, billingAddress, shippingAddress, promotionCode, datePlaced, null, null, null, null);
        }

        private void CalculateShippingCost()
        {
            ShippingCost = _costCalculatorService.CalculateShippingPrice(OrderLines.Select(x => x.Product).ToList(), ShippingAddress);
        }

        private void CalculateTotalCost()
        {
            TotalCost = _costCalculatorService.CalculateTotalPrice(OrderLines, PromotionCode);
        }

        public bool CanPlaceOrder(decimal expectedTotalCost, decimal expectedShippingCost)
        {
            //An order must have at least one line
            if (!OrderLines.Any())
                return false;
            
            //All products must be available to order
            foreach (var line in OrderLines)
            {
                if (!_productAvailabilityService.CheckProductAvailability(line.Product.Stockcode, line.Quantity))
                    return false;
            }

            //The calculated costs must match the expected ones 
            CalculateShippingCost();
            CalculateTotalCost();
            if (TotalCost != expectedTotalCost || ShippingCost != expectedShippingCost)
                return false;

            //if all checks succeeded, return true
            return true;
        }

        public void LoadTransitLocations()
        {
            TransitLocations = _orderTrackingRepository.GetTransitLocations(OrderId);
        }

        public void WithOrderTrackingRepository(IOrderTrackingRepository orderTrackingRepository)
        {
            _orderTrackingRepository = orderTrackingRepository;
        }
    }
}
