using MediatR;

namespace Application.Contracts.Features.MeasurementUnits.Commands.UpdateMeasurementUnit;

public sealed record UpdateMeasurementUnitCommand(
    UpdateMeasurementUnitRequestRouteDto RouteDto,
    UpdateMeasurementUnitRequestBodyDto BodyDto) : IRequest;