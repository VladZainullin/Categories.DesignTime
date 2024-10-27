using MediatR;

namespace Application.Contracts.Features.Categories.Commands.RemoveProductFromCategory;

public sealed record RemoveProductFromCategoryCommand(RemoveProductFromCategoryRequestRouteDto RouteDto) : IRequest;