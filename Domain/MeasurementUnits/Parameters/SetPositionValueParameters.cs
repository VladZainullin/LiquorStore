namespace Domain.MeasurementUnits.Parameters;

public readonly struct SetPositionValueParameters
{
    public required Guid MeasurementUnitPositionId { get; init; }

    public required string Value { get; init; }
}