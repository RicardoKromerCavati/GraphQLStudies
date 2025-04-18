using GraphQLSample.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.ConfigureApplication();

var app = builder.Build();

app.ConfigureApplication();

app.Run();
