using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OrderManagement.Contracts.Common
{
    public class Order
    {
        public int OrderId { get; }
        public List<OrderLine> OrderLines { get; }
        public int CustomerId { get; }
        public decimal ShippingCost { get; private set; }
        public decimal TotalCost { get; private set; }
        public Address ShippingAddress { get; }
        public Address BillingAddress { get; }
        public string PromotionCode { get; }
        public DateTime DatePlaced { get; }
        public List<TransitLocation> TransitLocations { get; private set; }

        [JsonConstructor]
        private Order(int orderId, List<OrderLine> orderLines, int customerId, decimal totalCost, decimal shippingCost, Address billingAddress, Address shippingAddress, string promotionCode, DateTime datePlaced, List<TransitLocation> transitLocations)
        {
            OrderId = orderId;
            OrderLines = orderLines;
            CustomerId = customerId;
            TotalCost = totalCost;
            ShippingCost = shippingCost;
            PromotionCode = promotionCode;
            DatePlaced = datePlaced;
            TransitLocations = transitLocations;
        }

        public static Order Create(int orderId, List<OrderLine> orderLines, int customerId, decimal totalCost, decimal shippingCost, Address billingAddress, Address shippingAddress, string promotionCode, DateTime datePlaced)
        {
            return new Order(orderId, orderLines, customerId, totalCost, shippingCost, billingAddress, shippingAddress, promotionCode, datePlaced, null);
        }
    }
}
