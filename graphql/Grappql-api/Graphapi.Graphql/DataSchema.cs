using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Graphapi.Graphql
{
    public class DataSchema : Schema
    {
        public DataSchema(IServiceProvider resolver):base(resolver)
        {
            Query = resolver.GetRequiredService<Query>();
            Mutation = resolver.GetRequiredService<ComponentMutation>();
        }
    }
}
