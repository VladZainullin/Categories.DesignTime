namespace Domain.Entities.Categories.Events;

public sealed class ProductDescriptionSetEvent
{
    public required Guid ProductId { get; init; }

    public required string Description { get; init; }
}