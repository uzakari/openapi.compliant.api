using Domain.Records.Response.People;

namespace Domain.Records.Response.Search;

public record SearchResponse(JokeSearchResponse JokeSearchResponse, PeopleApiResponse PeopleApiResponse);