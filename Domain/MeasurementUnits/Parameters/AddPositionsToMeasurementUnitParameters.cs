using Domain.MeasurementUnitPositions;

namespace Domain.MeasurementUnits.Parameters;

public readonly struct AddPositionsToMeasurementUnitParameters
{
    public required IEnumerable<MeasurementUnitPosition> MeasurementUnitPositions { get; init; }
}