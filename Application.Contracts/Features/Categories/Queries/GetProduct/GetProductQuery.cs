using MediatR;

namespace Application.Contracts.Features.Categories.Queries.GetProduct;

public sealed record GetProductQuery(GetProductRequestRouteDto RouteDto) : IRequest<GetProductResponseDto>;