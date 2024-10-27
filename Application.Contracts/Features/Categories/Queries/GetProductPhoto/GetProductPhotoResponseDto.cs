namespace Application.Contracts.Features.Categories.Queries.GetProductPhoto;

public sealed class GetProductPhotoResponseDto
{
    public required Stream Stream { get; init; }
}