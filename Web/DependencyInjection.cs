using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Minio;
using Web.Options;

namespace Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMinio(s =>
        {
            var minioOptions = configuration.GetSection("Minio").Get<MinioOptions>() 
                               ?? throw new InvalidOperationException("Minio options is null");
            s.WithCredentials(
                minioOptions.AccessKey, minioOptions.SecretKey);
            s.WithEndpoint(minioOptions.Endpoint);
            s.WithSSL(minioOptions.Ssl);
        });

        services.AddHealthChecks();
        services.AddControllers();
        
        return services;
    }

    private static IServiceCollection AddMinio(
        this IServiceCollection services,
        Action<IMinioClient> configureClient,
        ServiceLifetime lifetime = ServiceLifetime.Singleton)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configureClient);

        var client = new MinioClient();
        var propertyInfo = typeof(MinioConfig)
            .GetProperty("ServiceProvider", BindingFlags.NonPublic | BindingFlags.Instance);

        configureClient(client);
        
        switch (lifetime)
        {
            case ServiceLifetime.Singleton:
                services.TryAddSingleton(CreateMinioClientWithServiceProvider);
                break;
            case ServiceLifetime.Scoped:
                services.TryAddScoped(CreateMinioClientWithServiceProvider);
                break;
            case ServiceLifetime.Transient:
                services.TryAddTransient(CreateMinioClientWithServiceProvider);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(lifetime), lifetime, null);
        }

        return services;

        MinioClient CreateMinioClientWithServiceProvider(IServiceProvider serviceProvider)
        {
            propertyInfo?.SetValue(client.Config, serviceProvider);

            return client;
        }
    }
}