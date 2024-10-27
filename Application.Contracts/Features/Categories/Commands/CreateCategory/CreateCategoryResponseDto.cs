namespace Application.Contracts.Features.Categories.Commands.CreateCategory;

public sealed class CreateCategoryResponseDto
{
    public required Guid CategoryId { get; init; }
}