using MediatR;

namespace Application.Contracts.Features.MeasurementUnits.Commands.RemovePositionsFromMeasurementUnit;

public sealed record RemovePositionsFromMeasurementUnitCommand(
    RemovePositionsFromMeasurementUnitRequestRouteDto RouteDto,
    RemovePositionsToMeasurementUnitRequestBodyDto BodyDto) : 
    IRequest;