namespace Domain.Entities.Products.Parameters;

public readonly struct SetProductDescriptionParameters
{
    public required string Description { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}