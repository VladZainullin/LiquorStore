using Domain.MeasurementUnitPositions;

namespace Domain.MeasurementUnits.Parameters;

public readonly struct CreateMeasurementUnitParameters
{
    public required string Title { get; init; }

    public required IEnumerable<CreateMeasurementUnitPositionParameters> MeasurementUnitPositions { get; init; }
    
    public readonly struct CreateMeasurementUnitPositionParameters
    {
        public required string Value { get; init; }
    }
}