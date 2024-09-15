using MediatR;

namespace Application.Contracts.Features.MeasurementUnits.Commands.UpdateMeasurementUnitPosition;

public sealed record UpdateMeasurementUnitPositionCommand(
    UpdateMeasurementUnitPositionRequestRouteDto RouteDto,
    UpdateMeasurementUnitPositionRequestBodyDto BodyDto) : IRequest;