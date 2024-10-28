using Application.Contracts.Features.Categories.Commands.CreateCategory;
using Domain.Entities.Categories;
using Domain.Entities.Categories.Parameters;
using MediatR;
using Persistence.Contracts;

namespace Application.Features.Categories.Commands.CreateCategory;

internal sealed class CreateCategoryHandler(
    IDbContext context,
    TimeProvider timeProvider) :
    IRequestHandler<CreateCategoryCommand, CreateCategoryResponseDto>
{
    public async Task<CreateCategoryResponseDto> Handle(CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
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