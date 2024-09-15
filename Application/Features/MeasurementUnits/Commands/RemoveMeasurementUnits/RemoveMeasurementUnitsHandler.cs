using Application.Contracts.Features.MeasurementUnits.Commands.RemoveMeasurementUnits;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.MeasurementUnits.Commands.RemoveMeasurementUnits;

file sealed class RemoveMeasurementUnitsHandler(IDbContext context) : 
    IRequestHandler<RemoveMeasurementUnitsCommand>
{
    public async Task Handle(RemoveMeasurementUnitsCommand request, CancellationToken cancellationToken)
    {
        var measurementUnits = await context.MeasurementUnits
            .AsTracking()
            .Include(static mu => mu.MeasurementUnitPositions)
            .Where(mu => request.BodyDto.MeasurementUnitIds.Contains(mu.Id))
            .ToListAsync(cancellationToken);

        context.MeasurementUnits.RemoveRange(measurementUnits);
        await context.SaveChangesAsync(cancellationToken);
    }
}