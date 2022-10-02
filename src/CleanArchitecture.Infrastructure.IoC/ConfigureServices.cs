using CleanArchitecture.Core.Application;
using CleanArchitecture.Infrastructure.DataAccess;
using CleanArchitecture.Infrastructure.Identity;
//using CleanArchitecture.Infrastructure.Logging;
using CleanArchitecture.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.IoC;

public static class ConfigureServices
{
    public static IServiceCollection AddInfraStructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataAccessServices(configuration);
        services.AddApplicationServices();
        //services.AddLoggingServices();
        services.AddIdentityServices();
        services.AddExternalServices();

        return services;
    }
}