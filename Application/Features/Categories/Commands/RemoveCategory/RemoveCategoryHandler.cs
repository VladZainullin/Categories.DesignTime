using Application.Contracts.Features.Categories.Commands.RemoveCategory;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Features.Categories.Commands.RemoveCategory;

internal sealed class RemoveCategoryHandler(IDbContext context) : IRequestHandler<RemoveCategoryCommand>
{
    public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.GetAsync(new GetCategoryByIdParameters
        {
            CategoryId = request.RouteDto.CategoryId,
            AsTracking = true,
        }, cancellationToken);
        if (ReferenceEquals(category, default)) return;
        
        context.Categories.Remove(category);

        await context.SaveChangesAsync(cancellationToken);
    }
}