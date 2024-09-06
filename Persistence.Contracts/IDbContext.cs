using Domain.Entities.Products.Countries;

namespace Persistence.Contracts;

public interface IDbContext
{
    IDbSet<Country> Countries { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken);
}