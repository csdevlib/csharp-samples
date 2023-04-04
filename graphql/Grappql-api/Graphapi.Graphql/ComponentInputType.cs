using GraphQL.Types;

namespace Graphapi.Graphql
{
    public class ComponentInputType : InputObjectGraphType
    {
        public ComponentInputType()
        {
            Name = "ComponentInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("description");
            Field<NonNullGraphType<IntGraphType>>("productId");
        }
    }
}

