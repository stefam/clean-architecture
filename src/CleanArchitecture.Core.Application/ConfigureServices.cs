using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace CleanArchitecture.Core.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}