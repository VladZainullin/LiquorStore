using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
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

            options.UseNpgsql(connectionString, static o =>
            {
                o.CommandTimeout(10_000);
                o.MigrationsAssembly(HistoryRepository.DefaultTableName);
            });
        });

        services.AddScoped<DbContext>(sp => sp.GetRequiredService<AppDbContext>());
        services.AddScoped<AppDbContextAdapter>();
        services.AddScoped<IDbContext>(sp => sp.GetRequiredService<AppDbContextAdapter>());
        services.AddScoped<IMigrationContext>(sp => sp.GetRequiredService<AppDbContextAdapter>());
        services.AddScoped<ITransactionContext>(sp => sp.GetRequiredService<AppDbContextAdapter>());

        return services;
    }
}