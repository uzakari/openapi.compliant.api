using Domain.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DI.OpenApiHttpClients;

public static class OpenApiHttpClients
{
    public static IServiceCollection AddOpenApiHttpCliets(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient(OpenApiContant.CategoriesApi)
            .ConfigureHttpClient((serviceProvide, client) =>
            {
                client.BaseAddress = new Uri(configuration["ExternalService:CategoriesService:baseUri"]);
            });

        services.AddHttpClient(OpenApiContant.PeopleApi)
        .ConfigureHttpClient((serviceProvide, client) =>
        {
            client.BaseAddress = new Uri(configuration["ExternalService:PeopleService:baseUri"]);
        });

        return services;
    }
}
