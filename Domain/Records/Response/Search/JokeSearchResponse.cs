namespace Domain.Records.Response.Search;

public class JokeSearchResponse
{
    public int total { get; set; }
    public List<CategoriesDetails> result { get; set; }
}



public class CategoriesDetails
{
    public List<string> categories { get; set; }
    public string created_at { get; set; }
    public string icon_url { get; set; }
    public string id { get; set; }
    public string updated_at { get; set; }
    public string url { get; set; }
    public string value { get; set; }
}
