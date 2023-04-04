using OrderManagement.Domain;
using OrderManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace OrderManagement.Infrastructure.Repository
{
    /// <summary>
    /// Mock implementation of the order repository
    /// </summary>
    public class OrderRepository : IOrderRepository
    {   
        public Order Load(int orderId)
        {
            return Order.Create(
                orderId: 101,
                orderLines: new List<OrderLine>
                {
                    OrderLine.Create(
                        product:Product.Create(504421,"/image/504421/a.jpg", 392),
                        quantity:4,
                        unitPrice:40),
                    OrderLine.Create(
                        product:Product.Create(23151,"/image/23151/ce.jpg", 50),
                        quantity:2,
                        unitPrice:10),
                    OrderLine.Create(
                        product:Product.Create(40833,"/image/40833/gev.jpg", 22),
                        quantity:3,
                        unitPrice:14)
                },
                customerId: 5,
                totalCost: 408,
                shippingCost: 89,
                billingAddress: Address.Create("address1", "address2", "country"),
                shippingAddress: Address.Create("address1", "address2", "country"),
                promotionCode: "FIRSTBUY",
                datePlaced: DateTime.UtcNow);     
        }

        public List<Order> Search(int customerId)
        {
            return new List<Order>
            { Order.Create(
                orderId: 101,
                orderLines: new List<OrderLine>
                {
                    OrderLine.Create(
                        product:Product.Create(504421,"/image/504421/a.jpg", 392),
                        quantity:4,
                        unitPrice:40),
                    OrderLine.Create(
                        product:Product.Create(23151,"/image/23151/ce.jpg", 50),
                        quantity:2,
                        unitPrice:10),
                    OrderLine.Create(
                        product:Product.Create(40833,"/image/40833/gev.jpg", 22),
                        quantity:3,
                        unitPrice:14)
                },
                customerId: 5,
                totalCost: 408,
                shippingCost: 89,
                billingAddress: Address.Create("address1", "address2", "country"),
                shippingAddress: Address.Create("address1", "address2", "country"),
                promotionCode: "FIRSTBUY",
                datePlaced: DateTime.UtcNow),

              Order.Create(
                orderId: 156,
                orderLines: new List<OrderLine>
                {
                    OrderLine.Create(
                        product:Product.Create(504311,"/image/504311/a4.jpg", 34),
                        quantity:12,
                        unitPrice:35),
                    OrderLine.Create(
                        product:Product.Create(23333,"/image/23333/cf.jpg", 16),
                        quantity:25,
                        unitPrice:13)
                },
                customerId: 5,
                totalCost: 59,
                shippingCost: 39,
                billingAddress: Address.Create("address1", "address2", "country"),
                shippingAddress: Address.Create("address1", "address2", "country"),
                promotionCode: "",
                datePlaced: DateTime.UtcNow)
            };
        }

        public int Store(Order order)
        {
            return 503;
        }
    }
}
