using System.Collections.Generic;

namespace OrderManagement.Domain.Interfaces
{
    public interface IOrderRepository
    {
        int Store(Order order);
        Order Load(int orderId);
        List<Order> Search(int customerId);
    }
}
