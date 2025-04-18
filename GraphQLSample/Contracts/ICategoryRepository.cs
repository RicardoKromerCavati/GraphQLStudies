using GraphQLSample.Entities;

namespace GraphQLSample.Contracts;

public interface ICategoryRepository
{
    IEnumerable<Category> SelectAll();
    void CreateCategories(List<Category> categories);
}