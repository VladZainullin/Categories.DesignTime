using Application.Contracts.Features.Categories.Commands.UpdateProductPhoto;
using Domain.Entities.Categories.Parameters;
using MediatR;
using Minio;
using Minio.DataModel.Args;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Features.Categories.Commands.UpdateProductPhoto;

internal sealed class UpdateProductPhotoHandler(IDbContext context, IMinioClient minioClient, TimeProvider timeProvider)
    : IRequestHandler<UpdateProductPhotoCommand>
{
    public async Task Handle(UpdateProductPhotoCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.GetAsync(new GetCategoryByIdInputData
        {
            CategoryId = request.RouteDto.CategoryId,
            AsTracking = false,
            IncludeProducts = true
        }, cancellationToken);

        var product = category.Products.SingleOrDefault(p => p.Id == request.RouteDto.ProductId);
        if (ReferenceEquals(product, default))
        {
            return;
        }
        
        category.SetProductPhoto(new SetCategoryProductPhotoParameters
        {
            TimeProvider = timeProvider,
            ProductId = request.RouteDto.ProductId,
        });

        await context.SaveChangesAsync(cancellationToken);

        const string productPhotosBucket = "product-photos";
        var bucketExists = await minioClient.BucketExistsAsync(
            new BucketExistsArgs()
                .WithBucket(productPhotosBucket), cancellationToken);
        if (!bucketExists)
        {
            await minioClient.MakeBucketAsync(new MakeBucketArgs()
                .WithBucket(productPhotosBucket), cancellationToken);
        }

        await minioClient.PutObjectAsync(new PutObjectArgs()
            .WithBucket(productPhotosBucket)
            .WithObject(product.Photo.ToString())
            .WithStreamData(request.FormDto.Photo.OpenReadStream()), cancellationToken);
    }
}