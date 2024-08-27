using Application;
using Persistence;
using Serilog;
using Serilog.Exceptions;

namespace Web;

file static class Program
{
    public static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.WithExceptionDetails()
            .Enrich.FromLogContext()
            .Enrich.WithEnvironmentName()
            .Enrich.WithEnvironmentUserName()
            .Enrich.WithMachineName()
            .Enrich.WithThreadId()
            .Enrich.WithThreadName()
            .WriteTo.Console()
            .WriteTo.File("Logs/Log-.txt",
                rollingInterval: RollingInterval.Hour,
                rollOnFileSizeLimit: true)
            .WriteTo.Seq(
                serverUrl: "http://localhost:5341")
            .CreateBootstrapLogger();

        try
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration));

            builder.Services
                .AddPersistenceServices()
                .AddApplicationServices()
                .AddWebServices();

            await using var app = builder.Build();
            
            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseHealthChecks("/health");

            app.MapGraphQL();
            
            //app.MapControllers();

            await app.RunAsync();
        }
        catch (HostAbortedException)
        {
        }
        catch (Exception e)
        {
            Log.Fatal("Application not started. {error}", e);
        }
        finally
        {
            await Log.CloseAndFlushAsync();
        }
    }
}