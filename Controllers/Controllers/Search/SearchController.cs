using Application.Queries.Search.GetSearchResult;
using Domain.Records.Response.Search;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers.Search;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly IMediator _mediator;

    public SearchController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet()]
    public async Task<ActionResult<SearchResponse>> Search([FromQuery] string query)
    {
        return Ok(await _mediator.Send(new GetSearchResultQuery(query)));
    }
}
