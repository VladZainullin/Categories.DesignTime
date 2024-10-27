using MediatR;

namespace Application.Contracts.Features.Categories.Queries.GetProductPhoto;

public sealed record GetProductPhotoQuery(GetProductPhotoRequestRouteDto RouteDto) : IRequest<GetProductPhotoResponseDto>;