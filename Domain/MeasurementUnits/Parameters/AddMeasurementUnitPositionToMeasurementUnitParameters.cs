using Domain.MeasurementUnitPositions;

namespace Domain.MeasurementUnits.Parameters;

public readonly struct AddMeasurementUnitPositionToMeasurementUnitParameters
{
    public required IEnumerable<MeasurementUnitPosition> MeasurementUnitPositions { get; init; }
}