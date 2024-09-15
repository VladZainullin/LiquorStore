using Web.Middlewares;

namespace Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddScoped<TransactionMiddleware>();
        services.AddHealthChecks();
        services.AddControllers();
        
        return services;
    }
}