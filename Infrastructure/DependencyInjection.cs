using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionStrings = configuration.GetConnectionString("ProjectManagementDB");

        services.AddDbContext<AppDbContext>(cfg => cfg.UseSqlServer(connectionStrings));

        services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

        return services;
    }
}