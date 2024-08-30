namespace Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddHealthChecks();

        services.AddControllers();
        
        return services;
    }
}