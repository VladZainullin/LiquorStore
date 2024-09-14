namespace Application.Contracts.Features.MeasurementUnits.Commands.RemovePositionsFromMeasurementUnit;

public readonly struct RemovePositionsToMeasurementUnitRequestBodyDto
{
    public required IEnumerable<Guid> MeasurementUnitPositionIds { get; init; }
}