namespace Domain.Categories.Events;

public sealed class ProductQuantitySetEvent
{
    public required Guid ProductId { get; init; }

    public required int Quantity { get; init; }
}