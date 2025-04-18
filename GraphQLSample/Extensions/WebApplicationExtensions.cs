using GraphiQl;
using GraphQLSample.Contracts;
using GraphQLSample.Entities;
using GraphQLSample.GraphQL.GraphQLScheme;

namespace GraphQLSample.Extensions;

public static class WebApplicationExtensions
{
    private record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
    
    public static void ConfigureApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        app.MapGet("/weatherforecast", () =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                        new WeatherForecast
                        (
                            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            Random.Shared.Next(-20, 55),
                            summaries[Random.Shared.Next(summaries.Length)]
                        ))
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

        app.UseGraphQL<AppScheme>();
        app.UseGraphiQl();
        app.CreateData();
    }

    private static void CreateData(this WebApplication app)
    {
        var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        
        var categoryRepository = scope.ServiceProvider.GetRequiredService<ICategoryRepository>();
        
        var categories = new List<Category>()
        {
            new()
            {
                Name = "Technology",
                ImageUrl =
                    "www.google.com",
                Products = new List<Product>()
                {
                    new()
                    {
                        Name = "productName",
                        Description = "description",
                        ImageUrl = "https://stackoverflow.com/questions",
                        Price = 777,
                        RegisterDate = DateTime.Now,
                        Stock = 99
                    }
                }
            },
            new()
            {
                Name = "Food",
                ImageUrl =
                    "www.facebook.com",
                Products = new List<Product>()
                {
                    new()
                    {
                        Name = "productName2",
                        Description = "description2",
                        ImageUrl = "https://stackoverflow.com/questions",
                        Price = 888,
                        RegisterDate = DateTime.Now,
                        Stock = 199
                    }
                }
            }
        };
        
        categoryRepository.CreateCategories(categories);
    }
}