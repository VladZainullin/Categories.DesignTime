using Application.Contracts.Features.Categories.Queries.GetCategory;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Features.Categories.Queries.GetCategory;

internal sealed class GetCategoryHandler(IDbContext context) : 
    IRequestHandler<GetCategoryQuery, GetCategoryResponseDto>
{
    public async Task<GetCategoryResponseDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.GetAsync(new GetCategoryByIdParameters
        {
            CategoryId = request.RouteDto.CategoryId,
            AsTracking = false,
        }, cancellationToken);
        if (ReferenceEquals(category, default))
        {
            throw new ArgumentOutOfRangeException(nameof(request.RouteDto.CategoryId), "Category not found");
        }

        return new GetCategoryResponseDto
        {
            Id = category.Id,
            Title = category.Title
        };
    }
}