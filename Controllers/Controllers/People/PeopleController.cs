using Application.Queries.People.GetPeople;
using Domain.Records.Response.People;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers.People;

[Route("api/[controller]")]
[ApiController]
public class PeopleController : ControllerBase
{
    private readonly IMediator _meditor;

    public PeopleController(IMediator meditor)
    {
        _meditor = meditor;
    }

    [HttpGet("{pageNo?}")]
    public async Task<ActionResult<PeopleApiResponse>> People(string pageNo = default)
    {
        return Ok(await _meditor.Send(new GetPeopleQuery(pageNo)));
    }
}
