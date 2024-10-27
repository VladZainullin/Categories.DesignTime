namespace Domain.Entities.Categories.Events;

public sealed class ProductCostSetEvent
{
    public required Guid ProductId { get; init; }

    public required decimal Cost { get; init; }
}