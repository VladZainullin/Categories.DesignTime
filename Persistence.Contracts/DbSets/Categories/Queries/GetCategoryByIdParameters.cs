namespace Persistence.Contracts.DbSets.Categories.Queries;

public sealed class GetCategoryByIdParameters
{
    public required Guid CategoryId { get; init; }

    public required bool AsTracking { get; init; }
}