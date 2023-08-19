using Microsoft.Extensions.DependencyInjection;
using Shared;

namespace CSharpNewfeatures
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services
                .AddTransient<ISample, OutVariableSample>()
                .AddTransient<ISample, PatterMachingSample>()
                .AddTransient<ISample, TuplesSample>()
                .AddTransient<ISample, LocalFunctionSample>()
                .AddTransient<ISample, RefReturnsAndLocalSample>();

            return services;
        }

    }
}
