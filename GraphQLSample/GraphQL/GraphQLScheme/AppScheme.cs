using GraphQL.Types;
using GraphQLSample.GraphQL.GraphQLQueries;

namespace GraphQLSample.GraphQL.GraphQLScheme;

public class AppScheme : Schema
{
    public AppScheme(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Query = serviceProvider.GetRequiredService<AppQuery>();
    }
}