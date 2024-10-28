using Application.Contracts.Features.Categories.Queries.GetCategoryLogoUploadUrl;
using MediatR;
using Minio;
using Minio.DataModel.Args;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Features.Categories.Queries.GetCategoryLogoUploadUrl;

internal sealed class GetCategoryLogoUploadUrlHandler(IMinioClient minioClient, IDbContext context) : 
    IRequestHandler<GetCategoryLogoUploadUrlQuery, GetCategoryLogoUploadUrlResponseDto>
{
    public async Task<GetCategoryLogoUploadUrlResponseDto> Handle(GetCategoryLogoUploadUrlQuery request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.GetAsync(new GetCategoryByIdParameters
        {
            CategoryId = request.RouteDto.CategoryId,
            AsTracking = false
        }, cancellationToken);
        if (ReferenceEquals(category, default))
        {
            throw new ArgumentOutOfRangeException(nameof(request.RouteDto.CategoryId), "Category not found");
        }
        
        var presignedUrl = await minioClient.PresignedPutObjectAsync(new PresignedPutObjectArgs()
            .WithObject(category.LogoId.ToString())
            .WithBucket("categories")
            .WithExpiry(60 * 60));

        return new GetCategoryLogoUploadUrlResponseDto
        {
            Url = presignedUrl
        };
    }
}