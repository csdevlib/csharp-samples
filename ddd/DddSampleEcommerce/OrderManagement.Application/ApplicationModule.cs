using Autofac;
using OrderManagement.Application.Interfaces;

namespace OrderManagement.Application
{
    public class ApplicationModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderService>().As<IOrderService>();
        }
    }
}
