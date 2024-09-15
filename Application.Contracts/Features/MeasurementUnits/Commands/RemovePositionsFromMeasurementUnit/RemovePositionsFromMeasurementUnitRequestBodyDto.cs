// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.MeasurementUnits.Commands.RemovePositionsFromMeasurementUnit;

public sealed class RemovePositionsToMeasurementUnitRequestBodyDto
{
    public required IEnumerable<Guid> MeasurementUnitPositionIds { get; init; }
}