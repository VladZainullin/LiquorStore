using Domain.MeasurementUnitPositions;
using Domain.MeasurementUnits;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Persistence;

internal sealed class DbContextAdapter(DbContext context) : 
    IDbContext,
    IMigrationContext,
    ITransactionContext
{
    public IDbSet<MeasurementUnitPosition> MeasurementUnitPositions { get; } =
        new DbSetAdapter<MeasurementUnitPosition>(context);

    public IDbSet<MeasurementUnit> MeasurementUnits { get; } = 
        new DbSetAdapter<MeasurementUnit>(context);

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return context.SaveChangesAsync(cancellationToken: cancellationToken);
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