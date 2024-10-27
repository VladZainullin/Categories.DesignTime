namespace Domain.Entities.Categories.Parameters;

public readonly struct CreateCategoryParameters
{
    public required string Title { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}