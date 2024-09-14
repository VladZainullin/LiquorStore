using Application.Contracts.Features.MeasurementUnits.Commands.RemoveMeasurementUnits;
using Domain.MeasurementUnits.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.MeasurementUnits.Commands.RemoveMeasurementUnits;

file sealed class RemoveMeasurementUnitsHandler(IDbContext context, TimeProvider timeProvider) : 
    IRequestHandler<RemoveMeasurementUnitsCommand>
{
    public async Task Handle(RemoveMeasurementUnitsCommand request, CancellationToken cancellationToken)
    {
        var measurementUnits = await context.MeasurementUnits
            .AsTracking()
            .Include(static mu => mu.MeasurementUnitPositions)
            .Where(mu => request.BodyDto.MeasurementUnitIds.Contains(mu.Id))
            .ToListAsync(cancellationToken);

        foreach (var measurementUnit in measurementUnits)
        {
            measurementUnit.Remove(new RemoveMeasurementUnitParameters
            {
                TimeProvider = timeProvider
            });
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}