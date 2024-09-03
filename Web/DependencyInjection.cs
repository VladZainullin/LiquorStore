using Microsoft.Extensions.Options;
using Minio;
using Web.Options;

namespace Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddHealthChecks();
        services.AddOptions<MinioOptions>().BindConfiguration("MinioOptions");
        services.AddMinio(s =>
        {
            var serviceProvider = services.BuildServiceProvider();
            var minioOptionsSnapshot = serviceProvider.GetRequiredService<IOptionsSnapshot<MinioOptions>>();
            var minioOptions = minioOptionsSnapshot.Value;
            
            s.WithCredentials(minioOptions.AccessKey, minioOptions.SecretKey);
            s.WithEndpoint(minioOptions.Endpoint);
            s.WithSSL(minioOptions.Ssl);
        });

        services.AddControllers();
        
        return services;
    }
}