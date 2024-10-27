using Persistence.Contracts.DbSets.Categories;

namespace Persistence.Contracts;

public interface IDbContext
{
    ICategoryDbSet Categories { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}