namespace Application.Contracts.Features.Categories.Queries.GetCategoryLogo;

public sealed class GetCategoryLogoResponseDto
{
    public required Stream Stream { get; init; }
}