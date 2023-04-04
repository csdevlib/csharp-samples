using Graphapi.Data;
using GraphQL;
using GraphQL.Types;
using System.Collections.Generic;

namespace Graphapi.Graphql
{
    public class ProductType :  ObjectGraphType<Product>
    {
        public ProductType(IComponentRepository componentRepository)
        {
            Field(x => x.Id).Description("Product Id");
            Field(x => x.Name).Description("Product Name");
            Field(x => x.Price).Description("Product Price");
            Field(x => x.Description).Description("Product Description");
            Field<ListGraphType<ComponentType>>("components", resolve: context => componentRepository.GetComponentsByProductId(context.Source.Id));
            
            Field<ComponentType>("component", 
                arguments: new QueryArguments(new List<QueryArgument> {
                    new QueryArgument<IdGraphType> { Name = "id" },
                    new QueryArgument<StringGraphType> { Name = "name" },

                }),
                resolve: context =>
                {
                    var id = context.GetArgument<int?>("id");

                    if (id.HasValue)
                        return componentRepository.GetComponentById(id.Value);

                    var name = context.GetArgument<string>("name");

                    if (!string.IsNullOrEmpty(name))
                        return componentRepository.GetComponentByName(name, context.Source.Id);

                    return componentRepository.GetComponentsByProductId(context.Source.Id);
                });
        }
    }
}
