// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Categories.Parameters;

public readonly struct AddProductToCategoryParameters
{
    public required string Title { get; init; }

    public required string Description { get; init; }
        
    public required int Quantity { get; init; }

    public required decimal Cost { get; init; }

    public Guid Photo => Guid.NewGuid();

    public required TimeProvider TimeProvider { get; init; }
}