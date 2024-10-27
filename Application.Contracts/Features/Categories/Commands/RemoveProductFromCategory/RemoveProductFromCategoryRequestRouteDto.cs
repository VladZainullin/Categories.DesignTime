namespace Application.Contracts.Features.Categories.Commands.RemoveProductFromCategory;

public sealed class RemoveProductFromCategoryRequestRouteDto
{
    public required Guid CategoryId { get; init; }
    
    public required Guid ProductId { get; init; }
}