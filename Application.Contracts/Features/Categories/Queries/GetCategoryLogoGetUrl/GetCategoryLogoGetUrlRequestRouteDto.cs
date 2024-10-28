namespace Application.Contracts.Features.Categories.Queries.GetCategoryLogoGetUrl;

public sealed class GetCategoryLogoGetUrlRequestRouteDto
{
    public required Guid CategoryId { get; init; }
}