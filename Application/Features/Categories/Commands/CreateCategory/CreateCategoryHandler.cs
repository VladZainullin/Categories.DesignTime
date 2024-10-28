using Application.Contracts.Features.Categories.Commands.CreateCategory;
using Domain.Entities.Categories;
using Domain.Entities.Categories.Parameters;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Features.Categories.Commands.CreateCategory;

internal sealed class CreateCategoryHandler(
    IDbContext context,
    TimeProvider timeProvider) :
    IRequestHandler<CreateCategoryCommand, CreateCategoryResponseDto>
{
    public async Task<CreateCategoryResponseDto> Handle(CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var oldCategory = await context.Categories.GetAsync(new GetCategoriesByTitleParameters
        {
            Title = request.BodyDto.Title,
            AsTracking = default
        }, cancellationToken);
        if (!ReferenceEquals(oldCategory, default))
        {
            return new CreateCategoryResponseDto
            {
                CategoryId = oldCategory.Id
            };
        }
        
        var category = new Category(new CreateCategoryParameters
        {
            Title = request.BodyDto.Title,
            TimeProvider = timeProvider
        });

        context.Categories.Add(category);
        await context.SaveChangesAsync(cancellationToken);
        
        return new CreateCategoryResponseDto
        {
            CategoryId = category.Id
        };
    }
}