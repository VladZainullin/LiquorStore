namespace Application.Contracts.Features.MeasurementUnits.Commands.AddPositionsToMeasurementUnit;

public readonly struct AddPositionsToMeasurementUnitRequestBodyDto
{
    public required IEnumerable<string> Values { get; init; }
}