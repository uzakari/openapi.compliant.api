using Domain.Records.Response.People;

namespace Domain.Records.Response.Search;

public record SearchResponse(CategorySearchResponse CategorySearchResponse, PeopleApiResponse PeopleApiResponse);