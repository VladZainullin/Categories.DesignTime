namespace Application.Contracts.Features.Categories.Queries.GetCategory;

public sealed class GetCategoryResponseDto
{
    public required Guid Id { get; init; }

    public required string Title { get; init; }

    public required IEnumerable<ProductDto> Products { get; set; }
    
    public sealed class ProductDto
    {
        public required Guid Id { get; init; }

        public required string Title { get; init; }

        public required decimal Cost { get; init; }

        public required int Quantity { get; init; }
    }
}