using Application.Contracts.Features.Categories.Commands.UpdateProductInCategory;
using Application.Contracts.Features.Categories.Queries.GetProduct;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/categories/{categoryId:guid}/products/{productId:guid}")]
public sealed class ProductController : AppController
{
    [HttpGet]
    public async Task<ActionResult<GetProductResponseDto>> GetProductAsync(
        [FromRoute] GetProductRequestRouteDto routeDto)
    {
        return Ok(await Sender.Send(new GetProductQuery(routeDto), HttpContext.RequestAborted));
    }
    
    [HttpPut]
    public async Task<NoContentResult> UpdateProductInCategoryAsync(
        [FromRoute] UpdateProductInCategoryRequestRouteDto routeDto,
        [FromBody] UpdateProductInCategoryRequestBodyDto bodyDto)
    {
        await Sender.Send(new UpdateProductInCategoryCommand(routeDto, bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }
}