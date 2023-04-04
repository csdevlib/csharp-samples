using Graphapi.Data;
using GraphQL.Types;

namespace Graphapi.Graphql
{
    public class ComponentType : ObjectGraphType<Components>
    {
        public ComponentType()
        {
            Field(x => x.Id).Description("Product Id");
            Field(x => x.Name).Description("Product Name");
            Field(x => x.ProductId).Description("Product Id");
            Field(x => x.Description).Description("Product Description");
        }
    }
}
