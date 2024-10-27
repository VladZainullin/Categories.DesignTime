using MediatR;

namespace Application.Contracts.Features.Categories.Commands.CreateCategory;

public sealed record CreateCategoryCommand(
    CreateCategoryRequestFormDto FormDto) :
    IRequest<CreateCategoryResponseDto>;