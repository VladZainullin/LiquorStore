using Domain.Entities.Countries;
using Domain.Entities.Manufacturers;

namespace Persistence.Contracts;

public interface IAppDbContext
{
    IDbSet<Country> Countries { get; }
    
    IDbSet<Manufacturer> Manufacturer { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken);
}