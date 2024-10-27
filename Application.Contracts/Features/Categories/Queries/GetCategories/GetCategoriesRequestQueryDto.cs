namespace Application.Contracts.Features.Categories.Queries.GetCategories;

public sealed class GetCategoriesRequestQueryDto
{
    public required DateTimeOffset? GreaterThat { get; init; }

    public required int? Take { get; init; }
}