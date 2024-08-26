using Domain.Entities.Countries;

namespace Persistence.Contracts;

public interface IDbContext
{
    IDbSet<Country> Countries { get; }
    
    IDbSet<Country> Manufacturer { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
}