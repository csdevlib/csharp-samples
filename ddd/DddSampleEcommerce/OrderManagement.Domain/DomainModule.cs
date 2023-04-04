using Autofac;
using OrderManagement.Domain.Interfaces;
using OrderManagement.Domain.Services;

namespace OrderManagement.Domain
{
    public class DomainModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CostCalculatorService>().As<ICostCalculatorService>();
        }
    }
}
