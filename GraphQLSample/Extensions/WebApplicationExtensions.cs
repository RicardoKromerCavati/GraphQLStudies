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
                    "https://plus.unsplash.com/premium_photo-1683121716061-3faddf4dc504?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
            },
            new()
            {
                Name = "Food",
                ImageUrl =
                    "https://plus.unsplash.com/premium_photo-1667814373749-80583adf15a5?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
            }
        };
        
        categoryRepository.CreateCategories(categories);
    }
}