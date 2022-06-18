using Domain.Records.Response.Search;

namespace Application.Services.Search.Interface;

public interface ISearchService
{
    Task<SearchResponse> GetSearchResponse(string query);
}
