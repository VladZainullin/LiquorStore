namespace Application.Contracts.Features.MeasurementUnits.Commands.CreateMeasurementUnit;

public readonly struct CreateMeasurementUnitRequestBodyDto
{
    public required string Title { get; init; }

    public required IEnumerable<MeasurementUnitPositionDto> MeasurementUnitPositions { get; init; }
    
    public readonly struct MeasurementUnitPositionDto
    {
        public required Guid Id { get; init; }
    }
}