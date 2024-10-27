using MediatR;

namespace Application.Contracts.Features.Categories.Commands.UpdateCategoryLogo;

public sealed record UpdateCategoryLogoCommand(
    UpdateCategoryLogoRequestRouteDto RouteDto,
    UpdateCategoryLogoRequestFormDto FormDto) : IRequest;