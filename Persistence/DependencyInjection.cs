using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contracts;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContextPool<AppDbContext>(static (sp, options) =>
        {
            var connectionString = sp
                .GetRequiredService<IConfiguration>()
                .GetSection("DATABASE_CONNECTION")
                .Get<string>();

            options
                .UseSnakeCaseNamingConvention()
                .UseNpgsql(connectionString);
        });

        services.AddScoped<DbContext>(sp => sp.GetRequiredService<AppDbContext>());
        services.AddScoped<AppAppDbContextAdapter>();
        services.AddScoped<IAppDbContext>(sp => sp.GetRequiredService<AppAppDbContextAdapter>());
        services.AddScoped<IMigrationContext>(sp => sp.GetRequiredService<AppAppDbContextAdapter>());
        services.AddScoped<ITransactionContext>(sp => sp.GetRequiredService<AppAppDbContextAdapter>());

        return services;
    }
}