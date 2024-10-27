using Domain.Categories.Events;
using Domain.Entities.Categories.Parameters;
using Domain.Entities.Products;
using Domain.Entities.Products.Parameters;

namespace Domain.Entities.Categories;

public sealed class Category
{
    private Guid _id = Guid.NewGuid();

    private string _title = default!;
    
    private readonly List<Product> _products = [];

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

    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

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

    public void AddProduct(AddProductToCategoryParameters parameters)
    {
        var product = new Product(new CreateProductParameters
        {
            Title = parameters.Title,
            Description = parameters.Description,
            TimeProvider = parameters.TimeProvider,
            Photo = parameters.Photo,
            Quantity = parameters.Quantity,
            Cost = parameters.Cost
        });
        
        _products.Add(product);
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void RemoveProduct(RemoveProductFromCategoryParameters parameters)
    {
        var product = _products.SingleOrDefault(p => p.Id == parameters.ProductId);
        if (ReferenceEquals(product, default))
        {
            return;
        }
        
        _products.Remove(product);
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetProductTitle(SetCategoryProductTitleParameters parameters)
    {
        var productWithSameTitle = _products.SingleOrDefault(p => p.Title == parameters.Title);
        if (!ReferenceEquals(productWithSameTitle, default))
        {
            return;
        }
        
        var product = _products.SingleOrDefault(p => p.Id == parameters.ProductId);
        if (ReferenceEquals(product, default))
        {
            return;
        }

        if (product.Title == parameters.Title)
        {
            return;
        }
        
        if (parameters.Title == string.Empty)
        {
            return;
        }
        
        product.SetTitle(new SetProductTitleParameters
        {
            Title = parameters.Title,
            TimeProvider = parameters.TimeProvider
        });

        _updatedAt = parameters.TimeProvider.GetUtcNow();
        
        _domainEvents.Add(new ProductTitleSetEvent
        {
            ProductId = product.Id,
            Title = product.Title
        });
    }

    public void SetProductDescriptionTitle(SetCategoryProductDescriptionParameters parameters)
    {
        var product = _products.SingleOrDefault(p => p.Id == parameters.ProductId);
        if (ReferenceEquals(product, default))
        {
            return;
        }

        if (product.Description == parameters.Description)
        {
            return;
        }
        
        if (parameters.Description == string.Empty)
        {
            return;
        }
        
        product.SetDescription(new SetProductDescriptionParameters
        {
            Description = parameters.Description,
            TimeProvider = parameters.TimeProvider
        });

        _updatedAt = parameters.TimeProvider.GetUtcNow();
        
        _domainEvents.Add(new ProductDescriptionSetEvent
        {
            ProductId = product.Id,
            Description = product.Description
        });
    }

    public void SetProductCost(SetCategoryProductCostParameters parameters)
    {
        var product = _products.SingleOrDefault(p => p.Id == parameters.ProductId);
        if (ReferenceEquals(product, default))
        {
            return;
        }
        
        if (product.Cost == parameters.Cost)
        {
            return;
        }

        if (product.Cost < 0)
        {
            return;
        }
        
        product.SetCost(new SetProductCostParameters
        {
            Cost = parameters.Cost,
            TimeProvider = parameters.TimeProvider
        });
        
        _updatedAt = parameters.TimeProvider.GetUtcNow();
        
        _domainEvents.Add(new ProductCostSetEvent
        {
            ProductId = product.Id,
            Cost = product.Cost
        });
    }

    public void SetProductQuantity(SetCategoryProductQuantityParameters parameters)
    {
        var product = _products.SingleOrDefault(p => p.Id == parameters.ProductId);
        if (ReferenceEquals(product, default))
        {
            return;
        }

        if (product.Quantity == parameters.Quantity)
        {
            return;
        }

        if (product.Quantity < 0)
        {
            return;
        }
        
        product.SetQuantity(new SetProductQuantityParameters
        {
            Quantity = parameters.Quantity,
            TimeProvider = parameters.TimeProvider
        });
        _updatedAt = parameters.TimeProvider.GetUtcNow();
        
        _domainEvents.Add(new ProductQuantitySetEvent
        {
            ProductId = product.Id,
            Quantity = product.Quantity
        });
    }

    public void SetProductPhoto(SetCategoryProductPhotoParameters parameters)
    {
        var product = _products.SingleOrDefault(p => p.Id == parameters.ProductId);
        if (ReferenceEquals(product, default))
        {
            return;
        }
        
        product.UpdatePhoto(new SetProductPhotoParameters
        {
            TimeProvider = parameters.TimeProvider
        });

        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
}