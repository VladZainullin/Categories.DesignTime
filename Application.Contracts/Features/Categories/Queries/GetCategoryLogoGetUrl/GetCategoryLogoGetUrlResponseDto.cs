namespace Application.Contracts.Features.Categories.Queries.GetCategoryLogoGetUrl;

public sealed record GetCategoryLogoGetUrlResponseDto
{
    public required string Logo { get; init; }
}