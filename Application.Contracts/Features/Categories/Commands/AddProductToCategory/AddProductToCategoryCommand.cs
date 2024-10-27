using MediatR;

namespace Application.Contracts.Features.Categories.Commands.AddProductToCategory;

public sealed record AddProductToCategoryCommand(
    AddProductToCategoryRequestRouteDto RouteDto,
    AddProductToCategoryRequestFormDto FormDto) : IRequest<AddProductToCategoryResponseDto>;