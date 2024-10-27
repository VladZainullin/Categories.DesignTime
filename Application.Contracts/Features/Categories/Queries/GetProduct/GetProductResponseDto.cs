namespace Application.Contracts.Features.Categories.Queries.GetProduct;

public sealed class GetProductResponseDto
{
    public required string Title { get; init; }

    public required string Description { get; init; }

    public required decimal Cost { get; init; }

    public required int Quantity { get; init; }
}