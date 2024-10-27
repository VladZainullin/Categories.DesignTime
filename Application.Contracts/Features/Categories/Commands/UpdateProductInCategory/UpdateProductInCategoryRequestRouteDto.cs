// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Categories.Commands.UpdateProductInCategory;

public sealed class UpdateProductInCategoryRequestRouteDto
{
    public required Guid CategoryId { get; init; }

    public required Guid ProductId { get; init; }
}