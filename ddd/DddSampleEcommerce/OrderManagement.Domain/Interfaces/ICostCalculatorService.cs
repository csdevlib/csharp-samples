using System.Collections.Generic;

namespace OrderManagement.Domain.Interfaces
{
    public interface ICostCalculatorService
    {
        decimal CalculateTotalPrice(List<OrderLine> orderLines, string promotionCode);
        decimal CalculateShippingPrice(List<Product> products, Address shippingAddress);
    }
}
