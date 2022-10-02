using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Core.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CleanArchitecture.Infrastructure.Identity;

namespace CleanArchitecture.Infrastructure.DataAccess;

public static class ConfigureServices
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetValue<bool>("UseInMemoryDb"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("CleanArchitectureDb"));
        }
        else
        {
            var connectionString = configuration.GetConnectionString("SqliteConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString));
        }

        services.AddDefaultIdentity<ApplicationUser>(options =>
            options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        services.AddTransient<IRepositoryFactory, RepositoryFactory>();

        return services;
    }
}