namespace Application.Contracts.Features.Categories.Queries.GetCategory;

public sealed class GetCategoryRequestRouteDto
{
    public required Guid CategoryId { get; init; }
}