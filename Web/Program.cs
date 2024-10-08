using Application;
using Domain;
using MessageBroker;
using Persistence;
using Persistence.Contracts;
using Serilog;
using Web.Middlewares;


namespace Web;

file static class Program
{
    public static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();

        await using var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        try
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog(logger);

            builder.Services
                .AddDomainServices()
                .AddMessageBroker()
                .AddPersistenceServices()
                .AddApplicationServices()
                .AddWebServices();

            await using var app = builder.Build();

            var scope = app.Services.CreateAsyncScope();
            var migrationContext = scope.ServiceProvider.GetRequiredService<IMigrationContext>();
            await migrationContext.MigrateAsync();
            
            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseHealthChecks("/health");

            app.UseMiddleware<TransactionMiddleware>();
            app.MapControllers();

            await app.RunAsync();
        }
        catch (HostAbortedException)
        {
        }
        catch (Exception e)
        {
            logger.Fatal("Application not started. {error}", e);
        }
    }
}