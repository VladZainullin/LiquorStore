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

        var configureMinioClient = CreateMinioClient(configureClient); 
        
        switch (lifetime)
        {
            case ServiceLifetime.Singleton:
                services.TryAddSingleton(configureMinioClient);
                break;
            case ServiceLifetime.Scoped:
                services.TryAddScoped(configureMinioClient);
                break;
            case ServiceLifetime.Transient:
                services.TryAddTransient(configureMinioClient);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(lifetime), lifetime, null);
        }

        return services;

        static Func<IServiceProvider, IMinioClient> CreateMinioClient(Action<IMinioClient> configureClient)
        {
            var client = new MinioClient();
            configureClient(client);

            return serviceProvider =>
            {
                var propertyInfo = typeof(MinioConfig)
                    .GetProperty("ServiceProvider", BindingFlags.NonPublic | BindingFlags.Instance);

                propertyInfo?.SetValue(client.Config, serviceProvider);

                return client;
            };
        }
    }
}