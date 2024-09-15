// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.MeasurementUnits.Commands.AddPositionsToMeasurementUnit;

public sealed class AddPositionsToMeasurementUnitRequestRouteDto
{
    public required Guid MeasurementUnitId { get; init; }
}