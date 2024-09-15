// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.MeasurementUnits.Commands.RemovePositionsFromMeasurementUnit;

public sealed class RemovePositionsFromMeasurementUnitRequestRouteDto
{
    public required Guid MeasurementUnitId { get; init; }
}