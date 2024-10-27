namespace Domain.Entities.Categories.Parameters;

public readonly struct SetCategoryProductPhotoParameters
{
    public required Guid ProductId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}