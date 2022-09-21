using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Core.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.DataAccess;

public static class ConfigureServices
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("CleanArchitectureDb"));
        services.AddTransient<IRepositoryFactory, RepositoryFactory>();

        return services;
    }
}