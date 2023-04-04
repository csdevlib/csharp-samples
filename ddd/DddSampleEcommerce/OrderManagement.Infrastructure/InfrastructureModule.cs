using Autofac;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Interfaces;
using OrderManagement.Infrastructure.Repository;
using OrderManagement.Infrastructure.Services;

namespace OrderManagement.Infrastructure
{
    public class InfrastructureModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<OrderTrackingRepository>().As<IOrderTrackingRepository>();
            builder.RegisterType<ProductAvailabilityService>().As<IProductAvailabilityService>();
            builder.RegisterType<Publisher.Publisher>().As<IPublisher>();
        }
    }
}
