using Domain.MeasurementUnitPositions;

namespace Domain.ProductPositions.Parameters;

public readonly struct SetProductInstanceMeasurementUnitValueParameters
{
    public required MeasurementUnitPosition MeasurementUnitPosition { get; init; }
}