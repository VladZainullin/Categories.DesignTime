using Application.Contracts.Features.Categories.Commands.UpdateCategoryLogo;
using Domain.Entities.Categories.Parameters;
using MediatR;
using Minio;
using Minio.DataModel.Args;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Features.Categories.Commands.UpdateCategoryLogo;

internal sealed class UpdateCategoryLogoHandler(IDbContext context, IMinioClient minioClient, TimeProvider timeProvider) : 
    IRequestHandler<UpdateCategoryLogoCommand>
{
    public async Task Handle(UpdateCategoryLogoCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.GetAsync(new GetCategoryByIdInputData
        {
            CategoryId = request.RouteDto.CategoryId,
            AsTracking = false,
            IncludeProducts = true
        }, cancellationToken);
        
        category.SetLogoId(new SetCategoryProductLogoIdParameters
        {
            TimeProvider = timeProvider,
        });

        await context.SaveChangesAsync(cancellationToken);

        const string categoriesLogoBucket = "categories";
        var bucketExists = await minioClient.BucketExistsAsync(
            new BucketExistsArgs()
                .WithBucket(categoriesLogoBucket), cancellationToken);
        if (!bucketExists)
        {
            await minioClient.MakeBucketAsync(new MakeBucketArgs()
                .WithBucket(categoriesLogoBucket), cancellationToken);
        }

        await minioClient.PutObjectAsync(new PutObjectArgs()
            .WithBucket(categoriesLogoBucket)
            .WithObject(category.LogoId.ToString())
            .WithStreamData(request.FormDto.Logo.OpenReadStream()), cancellationToken);
    }
}