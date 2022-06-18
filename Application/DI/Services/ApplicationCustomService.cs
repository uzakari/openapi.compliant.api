using Application.Services.Categories;
using Application.Services.Categories.Interface;
using Application.Services.People;
using Application.Services.People.Interface;
using Application.Services.Search;
using Application.Services.Search.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DI.Services;

public static class ApplicationCustomService
{
    public static IServiceCollection AddApplicationCustomeService(this IServiceCollection services)
    {
        services.AddSingleton<ICategoriesService, CategoriesService>();
        services.AddSingleton<IPeopleService, PeopleService>();
        services.AddSingleton<ISearchService, SearchService>();
        return services;
    }
}
