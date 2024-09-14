using Domain.MeasurementUnits;

namespace Domain.MeasurementUnitPositions.Parameters;

public readonly struct CreateMeasurementUnitPositionParameters
{
    public required string Title { get; init; }

    public required MeasurementUnit MeasurementUnit { get; init; }
}