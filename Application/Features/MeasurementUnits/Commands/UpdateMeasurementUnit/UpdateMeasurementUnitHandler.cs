using Application.Contracts.Features.MeasurementUnits.Commands.UpdateMeasurementUnit;
using Domain.MeasurementUnits;
using Domain.MeasurementUnits.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.MeasurementUnits.Commands.UpdateMeasurementUnit;

file sealed class UpdateMeasurementUnitHandler(IDbContext context) : 
    IRequestHandler<UpdateMeasurementUnitCommand>
{
    public async Task Handle(UpdateMeasurementUnitCommand request, CancellationToken cancellationToken)
    {
        var measurementUnit = await GetMeasurementUnitAsync(request.RouteDto.MeasurementUnitId, cancellationToken);

        measurementUnit?.SetTitle(new SetMeasurementUnitTitleParameters
        {
            Title = request.BodyDto.Title
        });
        
        if (!ReferenceEquals(measurementUnit, default))
        {
            await context.SaveChangesAsync(cancellationToken);   
        }
    }

    private Task<MeasurementUnit?> GetMeasurementUnitAsync(Guid measurementUnitId, CancellationToken cancellationToken)
    {
        return context.MeasurementUnits
            .AsTracking()
            .Where(mu => mu.Id == measurementUnitId)
            .SingleOrDefaultAsync(cancellationToken);
    }
}