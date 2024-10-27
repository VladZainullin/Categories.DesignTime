using MediatR;

namespace Application.Contracts.Features.Categories.Commands.UpdateCategory;

public sealed record UpdateCategoryCommand(
    UpdateCategoryRequestRouteDto RouteDto,
    UpdateCategoryRequestBodyDto BodyDto) : IRequest;