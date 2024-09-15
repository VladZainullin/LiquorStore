// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.MeasurementUnits.Commands.RemovePositionsFromMeasurementUnit;

public readonly struct RemovePositionsFromMeasurementUnitRequestRouteDto
{
    public required Guid MeasurementUnitId { get; init; }
}