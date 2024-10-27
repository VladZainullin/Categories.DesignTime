namespace Application.Contracts.Features.Categories.Queries.GetProductPhoto;

public sealed class GetProductPhotoRequestRouteDto
{
    public required Guid CategoryId { get; init; }
    
    public required Guid ProductId { get; init; }
}