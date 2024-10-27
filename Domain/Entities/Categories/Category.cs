using Domain.Entities.Categories.Events;
using Domain.Entities.Categories.Parameters;

namespace Domain.Entities.Categories;

public sealed class Category
{
    private Guid _id = Guid.NewGuid();

    private string _title = default!;

    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;

    private List<object> _domainEvents = [];

    private Guid _logoId = Guid.NewGuid();

    private Category()
    {
    }

    public Category(CreateCategoryParameters parameters) : this()
    {
        SetTitle(new SetCategoryTitleParameters
        {
            Title = parameters.Title,
            TimeProvider = parameters.TimeProvider
        });

        _createdAt = parameters.TimeProvider.GetUtcNow();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
        
        _domainEvents.Add(new CategoryCreatedEvent
        {
            CategoryId = Id,
            Title = Title
        });
    }

    public Guid Id => _id;

    public string Title => _title;
    
    public DateTimeOffset CreatedAt => _createdAt;

    public DateTimeOffset UpdatedAt => _updatedAt;

    public Guid LogoId => _logoId;

    public void SetTitle(SetCategoryTitleParameters parameters)
    {
        if (_title == parameters.Title)
        {
            return;
        }
        
        _title = parameters.Title;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
        
        _domainEvents.Add(new CategoryTitleSetEvent
        {
            CategoryId = Id,
            Title = Title
        });
    }

    public void SetLogoId(SetCategoryProductLogoIdParameters parameters)
    {
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
}