namespace Domain.Entities.Categories.Events;

public sealed class CategoryCreatedEvent
{
    public required Guid CategoryId { get; init; }

    public required string Title { get; init; }
}