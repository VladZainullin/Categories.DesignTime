namespace Application.Contracts.Features.Categories.Queries.GetCategoryLogoUploadUrl;

public sealed class GetCategoryLogoUploadUrlRequestRouteDto
{
    public required Guid CategoryId { get; init; }
}