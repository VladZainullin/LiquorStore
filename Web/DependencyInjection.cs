using Domain.Entities.Countries;
using Domain.Entities.Manufacturers;
using Persistence.Contracts;

namespace Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        //services.AddControllers();
        services.AddHealthChecks();

        services
            .AddGraphQLServer()
            
            .ConfigureSchema(schemaBuilder =>
            {
                schemaBuilder.SetSchema(schemaTypeDescriptor => { schemaTypeDescriptor.Name("Countries"); });

                schemaBuilder.AddQueryType<Queries>();
                schemaBuilder
                    .AddProjections()
                    .AddFiltering();
            });

        return services;
    }
}

public sealed class Queries
{
    public IQueryable<Country> GetCountries([Service] IAppDbContext context) => context.Countries;
    
    public IQueryable<Manufacturer> GetManufacturers([Service] IAppDbContext context) => context.Manufacturer;
}