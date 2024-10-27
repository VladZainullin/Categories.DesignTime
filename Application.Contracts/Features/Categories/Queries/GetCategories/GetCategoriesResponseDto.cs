namespace Application.Contracts.Features.Categories.Queries.GetCategories;

public sealed class GetCategoriesResponseDto
{
    public required IEnumerable<CategoryDto> Categories { get; init; }
    
    public sealed class CategoryDto
    {
        public required Guid Id { get; init; }

        public required string Title { get; init; }
    }
}