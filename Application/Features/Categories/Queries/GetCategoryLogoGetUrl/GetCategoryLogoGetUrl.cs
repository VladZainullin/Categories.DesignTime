using Application.Contracts.Features.Categories.Queries.GetCategoryLogoUploadUrl;
using MediatR;
using Minio;
using Minio.DataModel.Args;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Features.Categories.Queries.GetCategoryLogoGetUrl;

internal sealed class GetCategoryLogoGetUrl(
    IDbContext context,
    IMinioClient minioClient) : IRequestHandler<GetCategoryLogoUploadUrlQuery, GetCategoryLogoUploadUrlResponseDto>
{
    public async Task<GetCategoryLogoUploadUrlResponseDto> Handle(GetCategoryLogoUploadUrlQuery request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.GetAsync(new GetCategoryByIdInputData
        {
            CategoryId = request.RouteDto.CategoryId,
            AsTracking = false,
        }, cancellationToken);

        var presignedUrl = await minioClient.PresignedGetObjectAsync(new PresignedGetObjectArgs()
            .WithObject(category.LogoId.ToString())
            .WithBucket("categories")
            .WithExpiry(60 * 60));

        return new GetCategoryLogoUploadUrlResponseDto
        {
            Url = presignedUrl
        };
    }
}