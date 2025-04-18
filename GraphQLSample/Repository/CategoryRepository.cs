using GraphQLSample.Contracts;
using GraphQLSample.Entities;
using GraphQLSample.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.Repository;

public class CategoryRepository(DatabaseContext databaseContext) : ICategoryRepository
{
    public IEnumerable<Category> SelectAll() => databaseContext.Categories.Include(c =>c.Products).ToList();
    public void CreateCategories(List<Category> categories)
    {
        databaseContext.Categories.AddRange(categories);
        databaseContext.SaveChanges();
    }

    public void CreateCategory(Category categories)
    {
        databaseContext.Categories.Add(categories);
        databaseContext.SaveChanges();
    }
}