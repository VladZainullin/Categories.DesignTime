namespace Persistence.Contracts.DbSets.Categories.Queries;

public sealed class GetCategoryByIdInputData
{
    public required Guid CategoryId { get; init; }

    public required bool AsTracking { get; init; }

    public required bool IncludeProducts { get; init; }
}