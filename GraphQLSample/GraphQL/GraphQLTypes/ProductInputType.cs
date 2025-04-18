using GraphQL.Types;
using GraphQLSample.Entities;

namespace GraphQLSample.GraphQL.GraphQLTypes;

public sealed class ProductInputType : InputObjectGraphType<Product>
{
    public ProductInputType()
    {
        Name = "ProductInput";
        Field<NonNullGraphType<StringGraphType>>("name");
        Field<NonNullGraphType<StringGraphType>>("description");
        Field<NonNullGraphType<DecimalGraphType>>("price");
        Field<NonNullGraphType<StringGraphType>>("imageUrl");
        Field<NonNullGraphType<DateGraphType>>("registerDate");
        Field<NonNullGraphType<FloatGraphType>>("stock");
    }
}