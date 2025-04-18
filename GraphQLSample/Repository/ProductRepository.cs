using GraphQLSample.Contracts;
using GraphQLSample.Entities.Context;

namespace GraphQLSample.Repository;

public class ProductRepository(DatabaseContext databaseContext) : IProductRepository
{
    
}