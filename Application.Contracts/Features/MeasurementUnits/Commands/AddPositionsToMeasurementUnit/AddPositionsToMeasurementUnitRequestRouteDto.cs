namespace Application.Contracts.Features.MeasurementUnits.Commands.AddPositionsToMeasurementUnit;

public readonly struct AddPositionsToMeasurementUnitRequestRouteDto
{
    public required Guid MeasurementUnitId { get; init; }
}