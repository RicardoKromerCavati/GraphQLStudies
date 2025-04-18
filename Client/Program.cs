using System.Text.Json;
using System.Text.Json.Serialization;
using Client.Models;
using Client.Models.Responses;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;

try
{
    var serializer = new SystemTextJsonSerializer();
    var client =
        new GraphQLHttpClient(options => { options.EndPoint = new Uri("https://localhost:44325/graphql"); }, serializer);

    // var request = new GraphQLHttpRequest()
    // {
    //     Query = @"query{categories {id,name} }"
    // };
    
    var request = new GraphQLRequest {
        Query = """
                {
                    categories {
                        id,
                        name,
                        imageUrl
                    }
                }
                """
    };
    
    var response = await client.SendQueryAsync<System.Text.Json.JsonElement>(request);

    var serializerOptions = new JsonSerializerOptions
    {
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    var categories = response.Data.Deserialize<CategoryResponse>(serializerOptions);

    if (categories is null)
    {
        Console.WriteLine("Could not deserialize categories");
        return;
    }
    
    foreach (var category in categories.Categories)
    {
        Console.WriteLine($"Category: {category.Name}");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}