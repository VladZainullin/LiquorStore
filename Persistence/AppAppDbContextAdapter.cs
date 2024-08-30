using Domain.Entities.Products.Countries;
using Domain.Entities.Products.Manufacturers;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Persistence;

internal sealed class AppAppDbContextAdapter(DbContext context) : 
    IAppDbContext,
    IMigrationContext,
    ITransactionContext
{
    public IDbSet<Country> Countries { get; } = new DbSetAdapter<Country>(context);
    public IDbSet<Manufacturer> Manufacturer { get; } = new DbSetAdapter<Manufacturer>(context);

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return context.SaveChangesAsync(cancellationToken);
    }

    public Task MigrateAsync(CancellationToken cancellationToken = default)
    {
        return context.Database.MigrateAsync(cancellationToken);
    }

    public Task BeginTransactionAsync(CancellationToken cancellationToken)
    {
        return context.Database.BeginTransactionAsync(cancellationToken);
    }

    public Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        return context.Database.CommitTransactionAsync(cancellationToken);
    }

    public Task RollbackTransactionAsync(CancellationToken cancellationToken)
    {
        return context.Database.RollbackTransactionAsync(cancellationToken);
    }
}