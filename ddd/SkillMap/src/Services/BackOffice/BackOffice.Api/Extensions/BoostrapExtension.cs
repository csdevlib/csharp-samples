using BackOffice.Application.Events.Integration;
using BackOffice.Domain.Companies;
using BackOffice.Domain.Tags;
using BackOffice.Infrastructure.EF.Repositories;
using MediatR;

namespace BackOffice.Api.Extensions
{
    public static class BoostrapExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration) 
        {
            // Mediator
            services.AddMediatR(typeof(Application.StartUp).Assembly);

            // Mapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Repository Patterns
            services.AddScoped<IWriteCompanyRepository, WriteCompanyRepository>();
            services.AddScoped<IWriteTagRepository, WriteTagRepository>();

            //IntegrationEvent Handler
            services.AddTransient<TagCreatedIntegrationEventHandler>();

            return services;
        }
    }
}
