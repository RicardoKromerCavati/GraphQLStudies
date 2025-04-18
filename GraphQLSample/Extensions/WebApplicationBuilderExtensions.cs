using GraphQL;
using GraphQL.SystemTextJson;
using GraphQLSample.Contracts;
using GraphQLSample.Entities.Context;
using GraphQLSample.GraphQL.GraphQLScheme;
using GraphQLSample.Repository;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void ConfigureApplication(this WebApplicationBuilder app)
    {
        app.Services.AddEndpointsApiExplorer();
        app.Services.AddSwaggerGen();
        app.Services.ConfigureDatabase().ConfigureGraphQl();
    }

    private static IServiceCollection ConfigureGraphQl(this IServiceCollection services)
    {
        services.AddScoped<AppScheme>();
        
        services.AddGraphQL(g =>
        {
            g.AddUnhandledExceptionHandler((c) =>
            {
                //VALIDATE THIS
                Console.WriteLine(c.Exception.Message);
            });
            g.AddGraphTypes();
        });

        services.AddTransient<IGraphQLTextSerializer, GraphQLSerializer>();

        return services;
    }

    private static IServiceCollection ConfigureDatabase(this IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("SuperMarketDatabase"));
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}