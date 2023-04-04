using OrderManagement.Domain.Interfaces;

namespace OrderManagement.Infrastructure.Services
{
    internal class ProductAvailabilityService : IProductAvailabilityService
    {
        public bool CheckProductAvailability(int stockCode, int quantity)
        {
            return true;
        }
    }
}
