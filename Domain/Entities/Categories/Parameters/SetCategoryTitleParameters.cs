namespace Domain.Entities.Categories.Parameters;

public readonly struct SetCategoryTitleParameters
{
    public required string Title { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}