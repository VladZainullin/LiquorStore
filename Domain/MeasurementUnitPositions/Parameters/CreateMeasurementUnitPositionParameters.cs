using Domain.MeasurementUnits;

namespace Domain.MeasurementUnitPositions.Parameters;

public readonly struct CreateMeasurementUnitPositionParameters
{
    public required string Value { get; init; }

    public required MeasurementUnit MeasurementUnit { get; init; }
}