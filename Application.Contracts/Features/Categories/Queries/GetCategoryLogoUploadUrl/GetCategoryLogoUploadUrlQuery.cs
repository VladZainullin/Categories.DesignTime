using MediatR;

namespace Application.Contracts.Features.Categories.Queries.GetCategoryLogoUploadUrl;

public sealed record GetCategoryLogoUploadUrlQuery(GetCategoryLogoUploadUrlRequestRouteDto RouteDto) : 
    IRequest<GetCategoryLogoUploadUrlResponseDto>;