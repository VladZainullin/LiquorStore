using Domain.MeasurementUnitPositions;
using Domain.MeasurementUnits;

namespace Persistence.Contracts;

public interface IDbContext
{
    IDbSet<MeasurementUnitPosition> MeasurementUnitPositions { get; }
    IDbSet<MeasurementUnit> MeasurementUnits { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
}