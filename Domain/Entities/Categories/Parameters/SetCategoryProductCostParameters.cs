namespace Domain.Entities.Categories.Parameters;

public readonly struct SetCategoryProductCostParameters
{
    public required Guid ProductId { get; init; }

    public required decimal Cost { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}