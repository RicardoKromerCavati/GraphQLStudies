# GraphQL in .NET
This project was created as a learning exercise to explore GraphQL.

## GraphQLSample
This is the API project, it contains the necessary files to allow clients to perform queries and mutations, all the necessary classes for it were created under the GraphQL folder.

In order for everything to work, on the `WebApplicationBuilderExtensions` class, the `AddGraphQL` method is called to configure the GraphQL server, on the same class I registered an instance for `IGraphQLTextSerializer` to enable communication between server and client.

On the `WebApplicationExtensions` I invoked `UseGraphQL` with my `AppScheme` as type parameter, and also the `UseGraphiQl` to allow tests via browser.

### (GraphQL) NuGet Packages Used
- [`GraphiQL`](https://github.com/graphql/graphiql)
- [`GraphQL`](https://www.nuget.org/packages/GraphQL)
- [`GraphQL.Server.Transports.AspNetCore`](https://www.nuget.org/packages/GraphQL.Server.Transports.AspNetCore/)
- [`GraphQL.Server.Transports.AspNetCore.SystemTextJson`](https://www.nuget.org/packages/GraphQL.Server.Transports.AspNetCore.SystemTextJson)

### Other NuGet Packages
In addition to the GraphQL packages, I also used Microsoft.EntityFrameworkCore.InMemory for data persistency tests. 

Microsoft.AspNetCore.OpenApi and Swashbuckle.AspNetCore were installed by default.

## Client
This project was created to be used as a client for the API, all of its logic is in Program.cs, which is responsible for creating a mutation and also querying available information.

All the necessary models were created under the Models folder.

### (GraphQL) NuGet Packages Used
- [`GraphQL.Client`](https://github.com/graphql-dotnet/graphql-client)
- [`GraphQL.Client.Serializer.SystemTextJson`](https://www.nuget.org/packages/GraphQL.Client.Serializer.SystemTextJson)


## Conclusion
To start the project I followed the example on the following links
- [ASP .NET Core - Usando GraphQL - I](https://www.macoratti.net/19/08/aspnc_grql1.htm)
- [ASP .NET Core - Usando GraphQL - II](https://www.macoratti.net/19/08/aspnc_grql2.htm)

During the development I encountered some challenges and these are the links that helped me the most (they are not in any kind of order!)
- [Writing mutation graphql-client c#](https://stackoverflow.com/questions/67858596/writing-mutation-graphql-client-c-sharp)
- [Variables](https://hygraph.com/docs/api-reference/content-api/variables)
- [What are GraphQL Mutations?](https://hygraph.com/learn/graphql/mutations)
- [Mutations](https://graphql-dotnet.github.io/docs/getting-started/mutations/)
- [Criando API GraphQL com .Net Core parte 1](https://jozimarback.medium.com/criando-api-graphql-com-net-core-cbe6618eb425)
- [How to run a mutation? Add example to Readme](https://github.com/graphql/graphiql/issues/72)