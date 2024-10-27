using Application.Contracts.Features.Categories.Commands.RemoveCategory;
using Application.Contracts.Features.Categories.Commands.UpdateCategory;
using Application.Contracts.Features.Categories.Queries.GetCategory;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/categories/{categoryId:guid}")]
public sealed class CategoryController : AppController
{
    [HttpGet]
    public async Task<ActionResult<GetCategoryResponseDto>> GetCategoryAsync(
        [FromRoute] GetCategoryRequestRouteDto routeDto)
    {
        return Ok(await Sender.Send(new GetCategoryQuery(routeDto), HttpContext.RequestAborted));
    }
    
    [HttpDelete]
    public async Task<NoContentResult> RemoveCategoryAsync(
        [FromRoute] RemoveCategoryRequestRouteDto routeDto)
    {
        await Sender.Send(new RemoveCategoryCommand(routeDto), HttpContext.RequestAborted);

        return NoContent();
    }

    [HttpPut]
    public async Task<NoContentResult> UpdateCategoryAsync(
        [FromRoute] UpdateCategoryRequestRouteDto routeDto,
        [FromBody] UpdateCategoryRequestBodyDto bodyDto)
    {
        await Sender.Send(new UpdateCategoryCommand(routeDto, bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }
}