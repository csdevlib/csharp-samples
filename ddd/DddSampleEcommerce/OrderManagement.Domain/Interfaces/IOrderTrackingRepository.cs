using System.Collections.Generic;

namespace OrderManagement.Domain.Interfaces
{
    public interface IOrderTrackingRepository
    {
        List<TransitLocation> GetTransitLocations(int orderId);
    }
}
