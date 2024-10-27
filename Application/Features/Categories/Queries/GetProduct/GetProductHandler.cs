using Application.Contracts.Features.Categories.Queries.GetProduct;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Features.Categories.Queries.GetProduct;

internal sealed class GetProductHandler(
    IDbContext context): IRequestHandler<GetProductQuery, GetProductResponseDto>
{
    public async Task<GetProductResponseDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.GetAsync(new GetCategoryByIdInputData
        {
            CategoryId = request.RouteDto.CategoryId,
            AsTracking = false,
            IncludeProducts = true
        }, cancellationToken);

        var product = category.Products.Single(p => p.Id == request.RouteDto.ProductId);
        return new GetProductResponseDto
        {
            Title = product.Title,
            Description = product.Description,
            Cost = product.Cost,
            Quantity = product.Quantity
        };
    }
}