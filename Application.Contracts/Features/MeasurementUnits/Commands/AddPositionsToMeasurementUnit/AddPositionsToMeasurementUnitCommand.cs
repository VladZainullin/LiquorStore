using MediatR;

namespace Application.Contracts.Features.MeasurementUnits.Commands.AddPositionsToMeasurementUnit;

public sealed record AddPositionsToMeasurementUnitCommand(
    AddPositionsToMeasurementUnitRequestRouteDto RouteDto,
    AddPositionsToMeasurementUnitRequestBodyDto BodyDto) : 
    IRequest;