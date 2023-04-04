using OrderManagement.Domain;
using OrderManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace OrderManagement.Infrastructure.Repository
{
    public class OrderTrackingRepository : IOrderTrackingRepository
    {
        public List<TransitLocation> GetTransitLocations(int orderId)
        {
            return new List<TransitLocation>
            {
                TransitLocation.Create(
                    name:"loc1",
                    date:DateTime.UtcNow,
                    Address.Create(
                        addressLine1:"addressLine1",
                        addressLine2:"addressLine2",
                        country:"country")),
                TransitLocation.Create(
                    name:"loc2",
                    date:DateTime.UtcNow,
                    Address.Create(
                        addressLine1:"addressLine1",
                        addressLine2:"addressLine2",
                        country:"country")),
            };
        }
    }
}
