using MediatR;

namespace Application.Contracts.Features.Categories.Queries.GetCategory;

public sealed record GetCategoryQuery(GetCategoryRequestRouteDto RouteDto) : IRequest<GetCategoryResponseDto>;