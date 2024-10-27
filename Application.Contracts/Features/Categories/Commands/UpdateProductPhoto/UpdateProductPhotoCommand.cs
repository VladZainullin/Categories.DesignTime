using MediatR;

namespace Application.Contracts.Features.Categories.Commands.UpdateProductPhoto;

public sealed record UpdateProductPhotoCommand(
    UpdateProductPhotoRequestRouteDto RouteDto,
    UpdateProductPhotoRequestFormDto FormDto) : IRequest;