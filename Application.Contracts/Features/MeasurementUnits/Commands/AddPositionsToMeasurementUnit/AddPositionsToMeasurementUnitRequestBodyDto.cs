// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.MeasurementUnits.Commands.AddPositionsToMeasurementUnit;

public sealed class AddPositionsToMeasurementUnitRequestBodyDto
{
    public required IEnumerable<MeasurementUnitPositionDto> MeasurementUnitPositions { get; init; }
    
    public sealed class MeasurementUnitPositionDto
    {
        public required string Value { get; init; }
    }
}