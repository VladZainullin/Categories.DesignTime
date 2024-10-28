namespace Persistence.Contracts.DbSets.Categories.Queries;

public sealed class GetCategoriesByTitleParameters
{
    public required string Title { get; init; }

    public required bool AsTracking { get; init; }
}