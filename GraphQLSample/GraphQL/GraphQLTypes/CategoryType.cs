using GraphQL.Types;
using GraphQLSample.Entities;

namespace GraphQLSample.GraphQL.GraphQLTypes;

public sealed class CategoryType : ObjectGraphType<Category>
{
    public CategoryType()
    {
        Field(x => x.Id, type: typeof(IdGraphType)).Description("Category ID");
        Field(x => x.Name).Description("Category Name");
        Field(x => x.ImageUrl).Description("Category Image URL");
    }
}