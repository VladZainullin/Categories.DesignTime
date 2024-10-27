namespace Domain.Entities.Categories.Parameters;

public readonly struct SetCategoryProductDescriptionParameters
{
    public required Guid ProductId { get; init; }
    
    public required string Description { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}