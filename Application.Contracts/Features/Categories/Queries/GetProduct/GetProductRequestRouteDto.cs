namespace Application.Contracts.Features.Categories.Queries.GetProduct;

public sealed class GetProductRequestRouteDto
{
    public required Guid CategoryId { get; init; }

    public required Guid ProductId { get; init; }
}