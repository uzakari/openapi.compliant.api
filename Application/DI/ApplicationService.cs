using Application.DI.Behaviour;
using Application.DI.OpenApiHttpClients;
using Application.DI.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.DI;

public static class ApplicationService
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddOpenApiHttpCliets(configuration)
            .AddApplicationCustomeService()
            .AddBehaviourService();

        return services;
    }
}
