using BackOffice.GraphApi.Graphql.Mutations;
using BackOffice.GraphApi.GraphQL.Resolvers;
using BackOffice.GraphApi.Middlewares;

namespace BackOffice.GraphApi.Extensions
{
    public static class GraphqlExtension
    {
        public static IServiceCollection AddGraphQL(this IServiceCollection services, IConfiguration configuration)
        {
            services
                 .AddGraphQLServer()
                 .UseField<DomainExceptionMiddleware>()
                 .AddMutationType<CompanyMutation>()
                 .AddAuthorization()
                 .AddQueryType<CompanyQuery>().AddFiltering().AddSorting();
            

            return services;
        }
    }
}

