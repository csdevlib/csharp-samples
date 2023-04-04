using Graphapi.Data;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;

namespace Graphapi.Graphql
{
    public class Query: ObjectGraphType
    {
        public Query(IProductRepository productRepository, IComponentRepository componentRepository)
        {
            Field<ListGraphType<ProductType>>("products", resolve: context => productRepository.GetAllProducts());
            Field<ProductType>("product",
                arguments: new QueryArguments(
                    new List<QueryArgument> {
                        new QueryArgument<IdGraphType> { Name = "id" },
                        new QueryArgument<StringGraphType> { Name = "name" }
                    }),
                resolve: context =>
                {
                    var id = context.GetArgument<int?>("id");

                    if (id.HasValue) 
                        return productRepository.GetProductById(id.Value);

                    var name = context.GetArgument<string>("name");

                    if (!string.IsNullOrEmpty(name)) 
                        return productRepository.GetProductByName(name);

                    return productRepository.GetAllProducts();
                });

            Field<ComponentType>("component",
                arguments: new QueryArguments(
                    new List<QueryArgument> {
                        new QueryArgument<IdGraphType> { Name = "id" },
                    }),
                resolve: context =>
                {
                    var id = context.GetArgument<int?>("id");

                    if (!id.HasValue) throw new Exception();

                    return componentRepository.GetComponentById(id.Value);
                    
                });
        }
    }
}
