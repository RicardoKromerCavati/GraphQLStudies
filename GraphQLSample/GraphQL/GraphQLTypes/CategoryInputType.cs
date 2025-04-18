using GraphQL.Types;
using GraphQLSample.Entities;

namespace GraphQLSample.GraphQL.GraphQLTypes;

public sealed class CategoryInputType : InputObjectGraphType<Category>
{
    public CategoryInputType()
    {
        Name = "CategoryInput";
        Field<NonNullGraphType<StringGraphType>>("name");
        Field<NonNullGraphType<StringGraphType>>("imageUrl");
        Field<NonNullGraphType<ListGraphType<ProductInputType>>>("products");
    }
}