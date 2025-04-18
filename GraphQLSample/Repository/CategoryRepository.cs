using GraphQLSample.Contracts;
using GraphQLSample.Entities;
using GraphQLSample.Entities.Context;

namespace GraphQLSample.Repository;

public class CategoryRepository(DatabaseContext databaseContext) : ICategoryRepository
{
    public IEnumerable<Category> SelectAll() => databaseContext.Categories.ToList();
    public void CreateCategories(List<Category> categories)
    {
        databaseContext.Categories.AddRange(categories);
        databaseContext.SaveChanges();
    }
}