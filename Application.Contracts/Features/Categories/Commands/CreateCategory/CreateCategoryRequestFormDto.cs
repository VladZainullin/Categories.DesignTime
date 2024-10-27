using Microsoft.AspNetCore.Http;

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Application.Contracts.Features.Categories.Commands.CreateCategory;

public sealed class CreateCategoryRequestFormDto
{
    public required string Title { get; init; }

    public required IFormFile Logo { get; init; }
}