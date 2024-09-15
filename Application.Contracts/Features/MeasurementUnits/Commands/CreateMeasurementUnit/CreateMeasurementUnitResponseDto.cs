// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.MeasurementUnits.Commands.CreateMeasurementUnit;

public readonly struct CreateMeasurementUnitResponseDto
{
    public required Guid MeasurementUnitId { get; init; }
}