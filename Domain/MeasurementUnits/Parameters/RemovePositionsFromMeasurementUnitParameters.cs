using Domain.MeasurementUnitPositions;

namespace Domain.MeasurementUnits.Parameters;

public readonly struct RemovePositionsFromMeasurementUnitParameters
{
    public required TimeProvider TimeProvider { get; init; }

    public required IEnumerable<MeasurementUnitPosition> MeasurementUnitPositions { get; init; }
}