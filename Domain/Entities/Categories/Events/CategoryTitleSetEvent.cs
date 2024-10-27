namespace Domain.Categories.Events;

public sealed class CategoryTitleSetEvent
{
    public required Guid CategoryId { get; init; }

    public required string Title { get; init; }
}