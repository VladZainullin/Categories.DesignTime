// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Application.Contracts.Features.Categories.Commands.CreateCategory;

public sealed class CreateCategoryRequestBodyDto
{
    public required string Title { get; init; }
}