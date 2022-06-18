using Application.Services.Search.Interface;
using Domain.Records.Response.Search;
using MediatR;

namespace Application.Queries.Search.GetSearchResult;

public record GetSearchResultQuery(string query) : IRequest<SearchResponse>;



public class GetSearchResultQueryHandler : IRequestHandler<GetSearchResultQuery, SearchResponse>
{
    private readonly ISearchService _searchService;

    public GetSearchResultQueryHandler(ISearchService searchService)
    {
        _searchService = searchService;
    }
    public async Task<SearchResponse> Handle(GetSearchResultQuery request, CancellationToken cancellationToken)
    {
        return await _searchService.GetSearchResponse(request.query);
    }
}
