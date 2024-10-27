using Application.Contracts.Features.Categories.Commands.RemoveProductFromCategory;
using Domain.Entities.Categories.Parameters;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Features.Categories.Commands.RemoveProductFromCategory;

internal class RemoveProductFromCategoryHandler(IDbContext context, TimeProvider timeProvider) : IRequestHandler<RemoveProductFromCategoryCommand>
{
    public async Task Handle(RemoveProductFromCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.GetAsync(new GetCategoryByIdInputData
        {
            CategoryId = request.RouteDto.CategoryId,
            AsTracking = true,
            IncludeProducts = true
        }, cancellationToken);
        
        category.RemoveProduct(new RemoveProductFromCategoryParameters
        {
            ProductId = request.RouteDto.ProductId,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}