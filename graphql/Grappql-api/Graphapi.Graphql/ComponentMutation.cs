using Graphapi.Data;
using GraphQL;
using GraphQL.Types;
using System.Collections.Generic;

namespace Graphapi.Graphql
{
    public class ComponentMutation : ObjectGraphType
    {
        public ComponentMutation(IComponentRepository componentRepository)
        {
            Field<ComponentType>("createComponent",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<NonNullGraphType<ComponentInputType>> { Name = "component" }
                }),
                resolve: context =>
                {
                    var component = context.GetArgument<Components>("component");
                    
                    return componentRepository.AddComponent(component);
                });
        }

    }
}
