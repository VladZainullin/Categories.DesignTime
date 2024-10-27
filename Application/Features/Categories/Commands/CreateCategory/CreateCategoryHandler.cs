using Application.Contracts.Features.Categories.Commands.CreateCategory;
using Domain.Entities.Categories;
using Domain.Entities.Categories.Parameters;
using MediatR;
using Minio;
using Minio.DataModel.Args;
using Persistence.Contracts;

namespace Application.Features.Categories.Commands.CreateCategory;

internal sealed class CreateCategoryHandler(
    IDbContext context,
    TimeProvider timeProvider,
    IMinioClient minioClient) :
    IRequestHandler<CreateCategoryCommand, CreateCategoryResponseDto>
{
    public async Task<CreateCategoryResponseDto> Handle(CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var category = new Category(new CreateCategoryParameters
        {
            Title = request.FormDto.Title,
            TimeProvider = timeProvider
        });

        context.Categories.Add(category);

        await context.SaveChangesAsync(cancellationToken);

        var bucketExistsArgs = new BucketExistsArgs()
            .WithBucket("categories");
        var bucketExists = await minioClient.BucketExistsAsync(bucketExistsArgs, cancellationToken);
        if (!bucketExists)
        {
            var makeBucketArgs = new MakeBucketArgs()
                .WithBucket("categories");
            await minioClient.MakeBucketAsync(makeBucketArgs, cancellationToken);
        }

        var putObjectArgs = new PutObjectArgs()
            .WithBucket("categories")
            .WithObject(category.LogoId.ToString())
            .WithObjectSize(request.FormDto.Logo.Length)
            .WithStreamData(request.FormDto.Logo.OpenReadStream());

        await minioClient.PutObjectAsync(putObjectArgs, cancellationToken);

        return new CreateCategoryResponseDto
        {
            CategoryId = category.Id
        };
    }
}