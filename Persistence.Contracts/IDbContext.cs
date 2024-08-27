using Domain.Entities.Countries;
using Domain.Entities.Tags;

namespace Persistence.Contracts;

public interface IDbContext
{
    IDbSet<Country> Countries { get; }
    
    IDbSet<Country> Manufacturer { get; }
    
    IDbSet<Tag> Tags { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
}