using MediatR;

namespace Application.Contracts.Features.Categories.Commands.UpdateProductInCategory;

public sealed record UpdateProductInCategoryCommand(
    UpdateProductInCategoryRequestRouteDto RouteDto,
    UpdateProductInCategoryRequestBodyDto BodyDto) : IRequest;