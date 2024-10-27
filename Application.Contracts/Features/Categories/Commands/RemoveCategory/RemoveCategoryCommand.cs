using MediatR;

namespace Application.Contracts.Features.Categories.Commands.RemoveCategory;

public sealed record RemoveCategoryCommand(RemoveCategoryRequestRouteDto RouteDto) : IRequest;