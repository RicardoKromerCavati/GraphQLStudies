using System.Text.Json;
using System.Text.Json.Serialization;
using Client.Models;
using Client.Models.Responses;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;

namespace Client;

internal abstract class Program
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new() { NumberHandling = JsonNumberHandling.AllowReadingFromString };
    public static async Task Main(string[] args)
    {
        try
        {
            const string apiUrl = "https://localhost:44325/graphql";
    
            var serializer = new SystemTextJsonSerializer();
            var client =
                new GraphQLHttpClient(options => { options.EndPoint = new Uri(apiUrl); }, serializer);
    
            var result = await CreateNewCategory(client);

            if (result is false)
            {
                return;
            }

            await GetAllCategoriesAndProducts(client);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private static async ValueTask<bool> GetAllCategoriesAndProducts(GraphQLHttpClient client)
    {
        const string query = """
                             {
                                 categories {
                                     id,
                                     name,
                                     imageUrl
                                     products {
                                         name, description, price, imageUrl, registerDate
                                     }
                                 }
                             }
                             """;
        
        var queryRequest = new GraphQLRequest { Query = query };
        
        var response = await client.SendQueryAsync<JsonElement>(queryRequest);

        var categoryResponse = response.Data.Deserialize<CategoryResponse>(JsonSerializerOptions);

        if (categoryResponse is null)
        {
            Console.WriteLine("Could not deserialize categories");
            return false;
        }
    
        foreach (var cat in categoryResponse.Categories)
        {
            Console.WriteLine($"Category: {cat}");
        }
        
        return true;
    }
    
    private static async ValueTask<bool> CreateNewCategory(GraphQLHttpClient client)
    {
        var categoryObj = new Category
        {
            Name = "categoryName",
            ImageUrl = "www.google.com",
            Products = new List<Product>
            {
                new()
                {
                    Name = "productName",
                    Description = "productDescription",
                    ImageUrl = "www.google.com",
                    Price = 12.99m,
                    RegisterDate = DateTime.Now.ToString("yyyy-MM-dd"),
                    Stock = 100
                },
                new()
                {
                    Name = "productName2",
                    Description = "productDescription2",
                    ImageUrl = "www.google.com2",
                    Price = 19.99m,
                    RegisterDate = DateTime.Now.ToString("yyyy-MM-dd"),
                    Stock = 999
                }
            }
        };

        const string mutation = """
                                mutation create($category: CategoryInput!) {
                                  createCategory(category: $category) {
                                    name,
                                    imageUrl,
                                    products {
                                      name,
                                      description,
                                      price,
                                      imageUrl,
                                      registerDate
                                    }
                                  }
                                }
                                """;

        var variables = new
        {
            category = categoryObj
        };

        var request = new GraphQLRequest
        {
            Query = mutation,
            Variables = variables
        };
    
        var response = await client.SendMutationAsync<CreateCategoryResponse>(request);

        if (response.Errors == null || response.Errors.Length == 0)
        {
            return true;
        }

        foreach (var err in response.Errors)
        {
            Console.WriteLine("Could not create category: {0}", err.Message);
            return false;
        }

        return true;
    }
}