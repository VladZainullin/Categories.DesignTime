using Microsoft.AspNetCore.Http;

namespace Application.Contracts.Features.Categories.Commands.UpdateProductPhoto;

public sealed class UpdateProductPhotoRequestFormDto
{
    public required IFormFile Photo { get; init; }
}