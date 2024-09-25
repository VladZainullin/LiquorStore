using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBroker;

public static class DependencyInjection
{
    public static IServiceCollection AddMessageBroker(this IServiceCollection services)
    {
        services.AddMassTransit(busRegistrationConfigurator =>
        {
            busRegistrationConfigurator.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(
                    host: "localhost",
                    port: 5672,
                    virtualHost: "/",
                    hostConfigurator =>
                    {
                        hostConfigurator.Username("administrator");
                        hostConfigurator.Password("administrator");
                    });

                configurator.AutoStart = true;

                configurator.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}