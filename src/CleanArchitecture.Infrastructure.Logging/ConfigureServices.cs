using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Logging;

public static class ConfigureServices
{
    public static IServiceCollection AddLoggingServices(this IServiceCollection services, string category = null, Func<LogLevel, bool> filter = null)
    {
        // TODO: Add services.

        return services;
    }
}