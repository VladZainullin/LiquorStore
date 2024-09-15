// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.MeasurementUnits.Commands.RemoveMeasurementUnits;

public readonly struct RemoveMeasurementUnitsRequestBodyDto
{
    public required IEnumerable<Guid> MeasurementUnitIds { get; init; }
}