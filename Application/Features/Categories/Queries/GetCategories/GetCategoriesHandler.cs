using Application.Contracts.Features.Categories.Queries.GetCategories;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Features.Categories.Queries.GetCategories;

internal sealed class GetCategoriesHandler(IDbContext context)
    : IRequestHandler<GetCategoriesQuery, GetCategoriesResponseDto>
{
    public async Task<GetCategoriesResponseDto> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await context.Categories.GetAsync(new GetCategoriesParameters
        {
            GreaterThat = request.QueryDto.GreaterThat,
            Take = request.QueryDto.Take,
            AsTracking = false,
            IncludeChildren = true
        }, cancellationToken);

        return new GetCategoriesResponseDto
        {
            Categories = categories.Select(c => new GetCategoriesResponseDto.CategoryDto
            {
                Id = c.Id,
                Title = c.Title,
            })
        };
    }
}