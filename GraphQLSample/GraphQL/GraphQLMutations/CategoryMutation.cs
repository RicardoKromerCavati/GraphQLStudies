using GraphQL;
using GraphQL.Types;
using GraphQLSample.Contracts;
using GraphQLSample.Entities;
using GraphQLSample.GraphQL.GraphQLTypes;

namespace GraphQLSample.GraphQL.GraphQLMutations;

public sealed class CategoryMutation : ObjectGraphType
{
    public CategoryMutation(ICategoryRepository categoryRepository)
    {
        Field<CategoryType>("createCategory")
            .Argument<NonNullGraphType<CategoryInputType>>("category")
            .Resolve(context =>
            {
                var category = context.GetArgument<Category>("category");
                
                categoryRepository.CreateCategory(category);
                
                return category;
            });
    }
}