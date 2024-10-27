namespace Domain.Entities.Products.Parameters;

public readonly struct SetProductQuantityParameters
{
    public required int Quantity { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}