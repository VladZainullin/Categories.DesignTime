using Domain.Entities.Categories;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Persistence.Contracts.DbSets.Categories;

public interface ICategoryDbSet : IDbSet<Category>
{
    Task<Category?> GetAsync(GetCategoryByIdParameters data, CancellationToken cancellationToken = default);
    
    Task<Category?> GetAsync(GetCategoriesByTitleParameters data, CancellationToken cancellationToken = default);
    
    Task<List<Category>> GetAsync(GetCategoriesParameters parameters, CancellationToken cancellationToken = default);
}