using Application.Contracts.Features.Categories.Commands.AddProductToCategory;
using Application.Contracts.Features.Categories.Commands.RemoveProductFromCategory;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/categories/{categoryId:guid}/products")]
public sealed class ProductsController : AppController
{
    [HttpPost]
    public async Task<NoContentResult> AddProductToCategoryAsync(
        [FromRoute] AddProductToCategoryRequestRouteDto routeDto,
        [FromForm] AddProductToCategoryRequestFormDto formDto)
    {
        await Sender.Send(new AddProductToCategoryCommand(routeDto, formDto), HttpContext.RequestAborted);

        return NoContent();
    }

    [HttpDelete]
    public async Task<NoContentResult> RemoveProductFromCategoryAsync(
        [FromRoute] RemoveProductFromCategoryRequestRouteDto routeDto)
    {
        await Sender.Send(new RemoveProductFromCategoryCommand(routeDto), HttpContext.RequestAborted);

        return NoContent();
    }
}