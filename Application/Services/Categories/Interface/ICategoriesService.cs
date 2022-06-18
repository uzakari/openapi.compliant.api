namespace Application.Services.Categories.Interface;

public interface ICategoriesService
{
    Task<List<string>> GetCategoriesAsync();
}
