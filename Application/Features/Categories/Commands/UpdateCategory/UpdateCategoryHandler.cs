using Application.Contracts.Features.Categories.Commands.UpdateCategory;
using Domain.Entities.Categories.Parameters;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Features.Categories.Commands.UpdateCategory;

internal sealed class UpdateCategoryHandler(IDbContext context, TimeProvider timeProvider) : 
    IRequestHandler<UpdateCategoryCommand>
{
    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.GetAsync(new GetCategoryByIdParameters
        {
            CategoryId = request.RouteDto.CategoryId,
            AsTracking = true,
        }, cancellationToken);
        if (ReferenceEquals(category, default)) return;
        
        category.SetTitle(new SetCategoryTitleParameters
        {
            Title = request.BodyDto.Title,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}