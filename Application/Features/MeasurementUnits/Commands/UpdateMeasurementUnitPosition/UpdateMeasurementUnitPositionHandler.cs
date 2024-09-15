using Application.Contracts.Features.MeasurementUnits.Commands.UpdateMeasurementUnitPosition;
using Domain.MeasurementUnits;
using Domain.MeasurementUnits.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.MeasurementUnits.Commands.UpdateMeasurementUnitPosition;

file sealed class UpdateMeasurementUnitPositionHandler(IDbContext context) : 
    IRequestHandler<UpdateMeasurementUnitPositionCommand>
{
    public async Task Handle(
        UpdateMeasurementUnitPositionCommand request,
        CancellationToken cancellationToken)
    {
        var measurementUnitId = request.RouteDto.MeasurementUnitId;
        
        var measurementUnit = await GetMeasurementUnitAsync(
            measurementUnitId,
            cancellationToken);

        if (!ReferenceEquals(measurementUnit, default))
        {
            measurementUnit.SetPositionValue(new SetPositionValueParameters
            {
                MeasurementUnitPositionId = request.RouteDto.MeasurementUnitPositionId,
                Value = request.BodyDto.Value
            });

            await context.SaveChangesAsync(cancellationToken);
        }
    }

    private Task<MeasurementUnit?> GetMeasurementUnitAsync(
        Guid routeDtoMeasurementUnitId,
        CancellationToken cancellationToken)
    {
        return context.MeasurementUnits
            .AsTracking()
            .Where(mu => mu.Id == routeDtoMeasurementUnitId)
            .SingleOrDefaultAsync(cancellationToken);
    }
}