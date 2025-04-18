using GraphQL.Types;
using GraphQLSample.Entities;

namespace GraphQLSample.GraphQL.GraphQLTypes;

public sealed class ProductType : ObjectGraphType<Product>
{
    public ProductType()
    {
        Field(expression: x => x.Id, type: typeof(IdGraphType)).Description("Id of Product");
        Field(x => x.Name).Description("Category Name");
        Field(x => x.ImageUrl).Description("Category Image URL");
        Field(x => x.Price).Description("Price of Product");
        Field(x => x.Description).Description("Description of Product");
        Field(x => x.RegisterDate).Description("Date of registration");
    }
}