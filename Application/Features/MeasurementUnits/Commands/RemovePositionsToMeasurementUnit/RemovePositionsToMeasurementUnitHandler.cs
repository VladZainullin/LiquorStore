using Application.Contracts.Features.MeasurementUnits.Commands.RemovePositionsFromMeasurementUnit;
using Domain.MeasurementUnitPositions;
using Domain.MeasurementUnits;
using Domain.MeasurementUnits.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.MeasurementUnits.Commands.RemovePositionsToMeasurementUnit;

file sealed class RemovePositionsToMeasurementUnitHandler(IDbContext context) : 
    IRequestHandler<RemovePositionsFromMeasurementUnitCommand>
{
    public async Task Handle(
        RemovePositionsFromMeasurementUnitCommand request,
        CancellationToken cancellationToken)
    {
        var measurementUnit = await GetMeasurementUnitAsync(request, cancellationToken);

        var addableMeasurementUnitPositions = 
            await GetAddableMeasurementUnitPositionsAsync(request, cancellationToken);
        
        measurementUnit.RemovePositions(new RemovePositionsFromMeasurementUnitParameters
        {
            MeasurementUnitPositions = addableMeasurementUnitPositions,
        });

        await context.SaveChangesAsync(cancellationToken);
    }

    private Task<MeasurementUnit> GetMeasurementUnitAsync(RemovePositionsFromMeasurementUnitCommand request, CancellationToken cancellationToken)
    {
        return context.MeasurementUnits
            .AsTracking()
            .Include(static mu => mu.MeasurementUnitPositions)
            .SingleAsync(
                mu => mu.Id == request.RouteDto.MeasurementUnitId,
                cancellationToken);
    }

    private Task<List<MeasurementUnitPosition>> GetAddableMeasurementUnitPositionsAsync(
        RemovePositionsFromMeasurementUnitCommand request,
        CancellationToken cancellationToken)
    {
        return context.MeasurementUnitPositions
            .AsTracking()
            .Where(mup => request.BodyDto.MeasurementUnitPositionIds.Contains(mup.Id))
            .ToListAsync(cancellationToken);
    }
}