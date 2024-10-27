namespace Domain.Categories.Events;

public sealed class ProductCreatedEvent
{
    public required Guid ProductId { get; init; }

    public required string Title { get; init; }

    public required string Description { get; init; }

    public required Guid Logo { get; init; }

    public required decimal Cost { get; init; }

    public required int Quantity { get; init; }

    public required Guid CetegoryId { get; init; }

    public required string CategoryTitle { get; set; }
}