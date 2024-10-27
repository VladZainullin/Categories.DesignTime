using MediatR;

namespace Application.Contracts.Features.Categories.Queries.GetCategoryLogo;

public sealed record GetCategoryLogoQuery(GetCategoryLogoRequestRouteDto RouteDto) : IRequest<GetCategoryLogoResponseDto>;