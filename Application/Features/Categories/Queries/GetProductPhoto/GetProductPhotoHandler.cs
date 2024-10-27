using Application.Contracts.Features.Categories.Queries.GetProductPhoto;
using MediatR;
using Minio;
using Minio.DataModel.Args;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Features.Categories.Queries.GetProductPhoto;

internal sealed class GetProductPhotoHandler(IDbContext context, IMinioClient minioClient) :
    IRequestHandler<GetProductPhotoQuery, GetProductPhotoResponseDto>
{
    public async Task<GetProductPhotoResponseDto> Handle(GetProductPhotoQuery request,
        CancellationToken cancellationToken)
    {
        var category = await context.Categories.GetAsync(new GetCategoryByIdInputData
        {
            CategoryId = request.RouteDto.CategoryId,
            AsTracking = false,
            IncludeProducts = true
        }, cancellationToken);

        var product = category.Products.Single(p => p.Id == request.RouteDto.ProductId);

        var presignedGetObjectArgs = new PresignedGetObjectArgs()
            .WithObject(product.Photo.ToString())
            .WithBucket("product_photos");
        var a = await minioClient.PresignedGetObjectAsync(presignedGetObjectArgs);

        var httpClient = new HttpClient();
        var stream = await httpClient.GetStreamAsync(a, cancellationToken);
        httpClient.Dispose();

        return new GetProductPhotoResponseDto
        {
            Stream = stream
        };
    }
}