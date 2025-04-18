using GraphQL.Types;
using GraphQLSample.Contracts;
using GraphQLSample.GraphQL.GraphQLTypes;

namespace GraphQLSample.GraphQL.GraphQLQueries;

public sealed class AppQuery : ObjectGraphType
{
    public AppQuery(ICategoryRepository categoryRepository)
    {
        Field<ListGraphType<CategoryType>>("categories").Resolve(_ => categoryRepository.SelectAll()); 
    }
}