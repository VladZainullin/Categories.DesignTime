namespace Domain.Entities.Categories.Parameters;

public sealed class SetCategoryProductQuantityParameters
{
    public required Guid ProductId { get; init; }

    public required int Quantity { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}