using Domain.Records.Response.People;

namespace Application.Services.People.Interface;

public interface IPeopleService
{
    public Task<PeopleApiResponse> GetPeopleAsync(string page);
}
