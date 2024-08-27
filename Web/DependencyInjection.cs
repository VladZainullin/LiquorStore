using Domain.Entities.Countries;
using Persistence.Contracts;
using Tag = Domain.Entities.Tags.Tag;

namespace Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        //services.AddControllers();
        services.AddHealthChecks();

        services
            .AddGraphQLServer()
            .AddQueryType<Queries>();
        
        return services;
    }
}

public class Queries
{
    public IQueryable<Tag> GetTags([Service] IDbContext context) => 
        context.Tags;

    public IQueryable<Country> GetManufacturers([Service] IDbContext context) =>
        context.Countries;
}