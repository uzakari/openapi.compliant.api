using Application.Services.Categories.Interface;
using Domain.Constants;
using Newtonsoft.Json;

namespace Application.Services.Categories;

public class CategoriesService : ICategoriesService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CategoriesService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<List<string>> GetCategoriesAsync()
    {
        var client =  _httpClientFactory.CreateClient(OpenApiContant.CategoriesApi);
        var request = new HttpRequestMessage(HttpMethod.Get, "jokes/categories");
        var response = await client.SendAsync(request);

        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();  
        var toReturn = JsonConvert.DeserializeObject<List<string>>(content);    
        return toReturn;
    }
}
