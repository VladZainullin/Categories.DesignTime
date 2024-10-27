// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Categories.Commands.UpdateProductInCategory;

public sealed class UpdateProductInCategoryRequestBodyDto
{
    public required string Title { get; init; }

    public required string Description { get; init; }

    public required int Quantity { get; init; }

    public required decimal Cost { get; init; }
}