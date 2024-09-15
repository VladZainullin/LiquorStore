namespace Application.Contracts.Features.MeasurementUnits.Commands.UpdateMeasurementUnitPosition;

public sealed class UpdateMeasurementUnitPositionRequestRouteDto
{
    public required Guid MeasurementUnitId { get; init; }

    public required Guid MeasurementUnitPositionId { get; init; }
}