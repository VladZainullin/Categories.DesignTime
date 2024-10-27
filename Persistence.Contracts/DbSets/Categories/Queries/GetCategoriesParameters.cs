namespace Persistence.Contracts.DbSets.Categories.Queries;

public readonly struct GetCategoriesParameters
{
    public required DateTimeOffset? GreaterThat { get; init; }

    public required int? Take { get; init; }
    
    public required bool AsTracking { get; init; }

    public required bool IncludeChildren { get; init; }
}