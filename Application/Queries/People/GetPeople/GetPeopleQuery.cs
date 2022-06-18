using Application.Services.People.Interface;
using Domain.Records.Response.People;
using MediatR;

namespace Application.Queries.People.GetPeople;

public record GetPeopleQuery(string pageNo) : IRequest<PeopleApiResponse>;



public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, PeopleApiResponse>
{
    private readonly IPeopleService _peopleService;

    public GetPeopleQueryHandler(IPeopleService peopleService)
    {
        _peopleService = peopleService;
    }
    public async Task<PeopleApiResponse> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
    {
        return await _peopleService.GetPeopleAsync(request.pageNo);
    }
}
