using BackOffice.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace BackOffice.GraphApi.Extensions
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<DbContext, BackOfficeContext>();

            services.AddDbContext<BackOfficeContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("BackofficeDatabase")),
                    ServiceLifetime.Singleton);


            return services;
        }
    }
}
