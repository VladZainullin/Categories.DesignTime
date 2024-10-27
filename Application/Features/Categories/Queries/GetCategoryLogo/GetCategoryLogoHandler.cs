using Application.Contracts.Features.Categories.Queries.GetCategoryLogo;
using MediatR;
using Minio;
using Minio.DataModel.Args;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Features.Categories.Queries.GetCategoryLogo;

internal sealed class GetCategoryLogoHandler(
    IDbContext context,
    IMinioClient minioClient) : IRequestHandler<GetCategoryLogoQuery, GetCategoryLogoResponseDto>
{
    public async Task<GetCategoryLogoResponseDto> Handle(GetCategoryLogoQuery request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.GetAsync(new GetCategoryByIdInputData
        {
            CategoryId = request.RouteDto.CategoryId,
            AsTracking = false,
            IncludeProducts = false
        }, cancellationToken);

        var filePath = await minioClient.PresignedGetObjectAsync(new PresignedGetObjectArgs()
            .WithObject(category.LogoId.ToString())
            .WithBucket("categories")
            .WithExpiry(60 * 60));

        var httpClient = new HttpClient();
        var stream = await httpClient.GetStreamAsync(filePath, cancellationToken);
        httpClient.Dispose();

        return new GetCategoryLogoResponseDto
        {
            Stream = stream
        };
    }
}