using CleanArchitecture.Core.Application;
using CleanArchitecture.Infrastructure.DataAccess;
using CleanArchitecture.Infrastructure.Identity;
using CleanArchitecture.Infrastructure.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.IoC;

public static class ConfigureServices
{
    public static IServiceCollection AddInfraStructureServices(this IServiceCollection services)
    {
        services.AddDataAccessServices();
        services.AddApplicationServices();
        services.AddLoggingServices();
        services.AddIdentityServices();

        return services;
    }
}