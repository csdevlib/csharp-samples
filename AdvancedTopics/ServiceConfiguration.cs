using AdvancedTopics;
using AdvancedTopics.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Shared;

namespace AdavancedTopics
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services
                .AddTransient<ISample, SystemTypeSample>();

            return services;
        }

    }
}
