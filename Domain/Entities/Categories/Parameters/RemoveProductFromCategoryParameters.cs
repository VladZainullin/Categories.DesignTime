namespace Domain.Entities.Categories.Parameters;

public readonly struct RemoveProductFromCategoryParameters
{
    public required Guid ProductId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}