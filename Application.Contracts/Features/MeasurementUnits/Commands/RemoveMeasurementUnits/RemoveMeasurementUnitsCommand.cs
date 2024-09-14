using MediatR;

namespace Application.Contracts.Features.MeasurementUnits.Commands.RemoveMeasurementUnits;

public sealed record RemoveMeasurementUnitsCommand(RemoveMeasurementUnitsRequestBodyDto BodyDto) : 
    IRequest;