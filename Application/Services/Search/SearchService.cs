using Application.Services.Search.Interface;
using Domain.Constants;
using Domain.Records.Response.People;
using Domain.Records.Response.Search;
using Newtonsoft.Json;

namespace Application.Services.Search;

public class SearchService : ISearchService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public SearchService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<SearchResponse> GetSearchResponse(string query)
    {

        var categoriesSearchResult = await GetCategoriesSearchResult(query);

        var peopleSearchResult = await GetPeopleSearchResult(query);

        return new SearchResponse(categoriesSearchResult, peopleSearchResult);

    }

    private async Task<PeopleApiResponse> GetPeopleSearchResult(string query)
    {
        var peopleClient = _httpClientFactory.CreateClient(OpenApiContant.PeopleApi);
        var peopleApiRequest = new HttpRequestMessage(HttpMethod.Get, $"api/people/?search={query}");
        var peopleApiResponse = await peopleClient.SendAsync(peopleApiRequest);
        peopleApiResponse.EnsureSuccessStatusCode();
        var peopleSearchContent = await peopleApiResponse.Content.ReadAsStringAsync();
        var peopleSearchResult = JsonConvert.DeserializeObject<PeopleApiResponse>(peopleSearchContent);
        return peopleSearchResult;
    }

    private async Task<JokeSearchResponse> GetCategoriesSearchResult(string query)
    {
        var categoriesClient = _httpClientFactory.CreateClient(OpenApiContant.CategoriesApi);
        var categoriesSearchRequest = new HttpRequestMessage(HttpMethod.Get, $"jokes/search?query={query}");
        var categoriesSearchResponse = await categoriesClient.SendAsync(categoriesSearchRequest);

        categoriesSearchResponse.EnsureSuccessStatusCode();
        var categoresSearchContent = await categoriesSearchResponse.Content.ReadAsStringAsync();
        var categoriesSearchResult = JsonConvert.DeserializeObject<JokeSearchResponse>(categoresSearchContent);

        return categoriesSearchResult;
    }
}
