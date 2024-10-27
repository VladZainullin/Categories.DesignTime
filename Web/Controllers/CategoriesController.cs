using Application.Contracts.Features.Categories.Commands.CreateCategory;
using Application.Contracts.Features.Categories.Queries.GetCategories;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/categories")]
public sealed class CategoriesController : AppController
{
    [HttpGet]
    public async Task<ActionResult<GetCategoriesResponseDto>> GetCategoriesAsync(
        [FromQuery] GetCategoriesRequestQueryDto queryDto)
    {
        return Ok(await Sender.Send(new GetCategoriesQuery(queryDto), HttpContext.RequestAborted));
    }
    
    [HttpPost]
    public async Task<ActionResult<CreateCategoryResponseDto>> CreateCategoryAsync(
        [FromForm] CreateCategoryRequestFormDto formDto)
    {
        return Ok(await Sender.Send(
            new CreateCategoryCommand(formDto), HttpContext.RequestAborted));
    }
}