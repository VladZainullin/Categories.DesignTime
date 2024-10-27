namespace Application.Contracts.Features.Categories.Queries.GetCategory;

public sealed class GetCategoryResponseDto
{
    public required Guid Id { get; init; }

    public required string Title { get; init; }
}