using Application.Queries.Categories.GetCategories;
using Domain.Records.Response.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers.Categories;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<CategoriesResponse>> Categories()
    {
        return Ok(await _mediator.Send(new GetCategoriesQuery()));
    }
}
