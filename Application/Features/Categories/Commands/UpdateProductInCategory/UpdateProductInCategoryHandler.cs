using Application.Contracts.Features.Categories.Commands.UpdateProductInCategory;
using Domain.Entities.Categories.Parameters;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Features.Categories.Commands.UpdateProductInCategory;

internal sealed class UpdateProductInCategoryHandler(IDbContext context, TimeProvider timeProvider) : 
    IRequestHandler<UpdateProductInCategoryCommand>
{
    public async Task Handle(UpdateProductInCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.GetAsync(new GetCategoryByIdInputData
        {
            CategoryId = request.RouteDto.CategoryId,
            AsTracking = true,
            IncludeProducts = true
        }, cancellationToken);

        category.SetProductTitle(new SetCategoryProductTitleParameters
        {
            ProductId = request.RouteDto.ProductId,
            Title = request.BodyDto.Title,
            TimeProvider = timeProvider
        });
        
        category.SetProductDescriptionTitle(new SetCategoryProductDescriptionParameters
        {
            ProductId = request.RouteDto.ProductId,
            Description = request.BodyDto.Description,
            TimeProvider = timeProvider
        });
        
        category.SetProductQuantity(new SetCategoryProductQuantityParameters
        {
            ProductId = request.RouteDto.ProductId,
            Quantity = request.BodyDto.Quantity,
            TimeProvider = timeProvider
        });
        
        category.SetProductCost(new SetCategoryProductCostParameters
        {
            ProductId = request.RouteDto.ProductId,
            Cost = request.BodyDto.Cost,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}