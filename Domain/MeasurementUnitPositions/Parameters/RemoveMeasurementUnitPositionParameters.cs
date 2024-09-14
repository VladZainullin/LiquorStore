namespace Domain.MeasurementUnitPositions.Parameters;

public readonly struct RemoveMeasurementUnitPositionParameters
{
    public required TimeProvider TimeProvider { get; init; }
}