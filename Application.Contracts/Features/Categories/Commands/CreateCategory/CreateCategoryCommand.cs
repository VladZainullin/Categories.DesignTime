using MediatR;

namespace Application.Contracts.Features.Categories.Commands.CreateCategory;

public sealed record CreateCategoryCommand(
    CreateCategoryRequestBodyDto BodyDto) :
    IRequest<CreateCategoryResponseDto>;