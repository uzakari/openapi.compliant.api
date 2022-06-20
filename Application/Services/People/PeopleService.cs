using Application.Services.People.Interface;
using Domain.Constants;
using Domain.Records.Response.People;
using Newtonsoft.Json;

namespace Application.Services.People;

public class PeopleService : IPeopleService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public PeopleService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<PeopleApiResponse> GetPeopleAsync(string? pageNo)
    {

        var client = _httpClientFactory.CreateClient(OpenApiContant.PeopleApi);

        var request = new HttpRequestMessage(HttpMethod.Get, $"api/people/{(!string.IsNullOrWhiteSpace(pageNo) ? $"?page={pageNo}" : string.Empty)}");
        var response = await client.SendAsync(request);

        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var toReturn = JsonConvert.DeserializeObject<PeopleApiResponse>(content);
        return toReturn;
    }
}
