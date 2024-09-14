using MediatR;

namespace Application.Contracts.Features.MeasurementUnits.Commands.CreateMeasurementUnit;

public sealed record CreateMeasurementUnitCommand(CreateMeasurementUnitRequestBodyDto BodyDto) : 
    IRequest<CreateMeasurementUnitResponseDto>;