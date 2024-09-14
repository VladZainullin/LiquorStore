using Domain.MeasurementUnitPositions;

namespace Domain.MeasurementUnits.Parameters;

public readonly struct RemoveMeasurementUnitPositionsFromMeasurementUnitParameters
{
    public TimeProvider TimeProvider { get; init; }

    public IEnumerable<MeasurementUnitPosition> MeasurementUnitPositions { get; init; }
}