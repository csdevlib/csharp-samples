using BackOffice.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using SkillMap.EventBus.EvenLogF;
using System.Reflection;

namespace BackOffice.Api.Extensions
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BackOfficeContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString:BackofficeDatabase"],
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(StartUp).GetTypeInfo().Assembly.GetName().Name);
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    });
            },
                        //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
                        ServiceLifetime.Scoped  
                    );

            services.AddDbContext<IntegrationEventLogContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString:BackofficeDatabase"],
                                        sqlServerOptionsAction: sqlOptions =>
                                        {
                                            sqlOptions.MigrationsAssembly(typeof(StartUp).GetTypeInfo().Assembly.GetName().Name);
                                        //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
                                            sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                        });
                                     });

            return services;
        }
    }
}
