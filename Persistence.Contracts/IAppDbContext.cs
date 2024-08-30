using Domain.Entities.Products.Countries;
using Domain.Entities.Products.Manufacturers;

namespace Persistence.Contracts;

public interface IAppDbContext
{
    IDbSet<Country> Countries { get; }
    
    IDbSet<Manufacturer> Manufacturer { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken);
}