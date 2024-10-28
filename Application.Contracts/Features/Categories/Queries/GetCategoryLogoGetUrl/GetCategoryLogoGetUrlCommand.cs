using MediatR;

namespace Application.Contracts.Features.Categories.Queries.GetCategoryLogoGetUrl;

public sealed record GetCategoryLogoGetUrlCommand(GetCategoryLogoGetUrlRequestRouteDto RouteDto) : 
    IRequest<GetCategoryLogoGetUrlResponseDto>;