using System.Net.Mime;
using Application.Contracts.Features.Categories.Commands.UpdateCategoryLogo;
using Application.Contracts.Features.Categories.Queries.GetCategoryLogo;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/categories/{categoryId:guid}/logos")]
public sealed class CategoryLogosController : AppController
{
    [HttpGet]
    public async Task<FileResult> GetCategoryLogoAsync(
        [FromRoute] GetCategoryLogoRequestRouteDto routeDto)
    {
        var response = await Sender.Send(new GetCategoryLogoQuery(routeDto), HttpContext.RequestAborted);
        
        return File(response.Stream, MediaTypeNames.Application.Octet);
    }

    [HttpPut]
    public async Task<NoContentResult> UpdateCategoryLogoAsync(
        [FromRoute] UpdateCategoryLogoRequestRouteDto routeDto,
        [FromForm] UpdateCategoryLogoRequestFormDto formDto)
    {
        await Sender.Send(new UpdateCategoryLogoCommand(routeDto, formDto), HttpContext.RequestAborted);
        
        return NoContent();
    }
}