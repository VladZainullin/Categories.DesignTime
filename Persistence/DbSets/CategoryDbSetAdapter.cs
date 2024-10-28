using Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts.DbSets.Categories;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Persistence.DbSets;

internal sealed class CategoryDbSetAdapter(AppDbContext context) :
    DbSetAdapter<Category>(context),
    ICategoryDbSet
{
    public Task<Category?> GetAsync(GetCategoryByIdParameters data, CancellationToken cancellationToken = default)
    {
        var queryable = context.Categories;

        if (data.AsTracking)
        {
            queryable.AsTracking();
        }
        else
        {
            queryable.AsNoTracking();
        }

        return queryable
            .Where(c => c.Id == data.CategoryId)
            .SingleOrDefaultAsync(cancellationToken);
    }

    public Task<List<Category>> GetAsync(
        GetCategoriesParameters parameters,
        CancellationToken cancellationToken = default)
    {
        var queryable = context.Categories.AsQueryable();

        if (parameters.AsTracking)
        {
            queryable = queryable.AsTracking();
        }
        
        if (parameters is { GreaterThat: not null, Take: > 0 })
        {
            queryable = queryable
                .OrderByDescending(static c => c.CreatedAt)
                .Where(c => c.CreatedAt > parameters.GreaterThat)
                .Take(parameters.Take.Value);
        }

        return queryable.ToListAsync(cancellationToken);
    }
}