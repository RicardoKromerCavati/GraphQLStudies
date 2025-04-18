using GraphQLSample.Entities;

namespace GraphQLSample.Contracts;

public interface ICategoryRepository
{
    IEnumerable<Category> SelectAll();
    void CreateCategory(Category categories);
    void CreateCategories(List<Category> categories);
}