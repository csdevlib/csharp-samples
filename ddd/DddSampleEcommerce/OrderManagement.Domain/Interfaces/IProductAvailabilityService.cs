namespace OrderManagement.Domain.Interfaces
{
    public interface IProductAvailabilityService
    {
        bool CheckProductAvailability(int stockCode, int quantity);
    }
}
