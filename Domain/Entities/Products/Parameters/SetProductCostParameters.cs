namespace Domain.Entities.Products.Parameters;

public readonly struct SetProductCostParameters
{
    public required decimal Cost { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}