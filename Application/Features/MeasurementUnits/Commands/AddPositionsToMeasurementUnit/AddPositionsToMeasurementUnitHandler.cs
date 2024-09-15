using Application.Contracts.Features.MeasurementUnits.Commands.AddPositionsToMeasurementUnit;
using Domain.MeasurementUnits;
using Domain.MeasurementUnits.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.MeasurementUnits.Commands.AddPositionsToMeasurementUnit;

file sealed class AddPositionsToMeasurementUnitHandler(IDbContext context) :
    IRequestHandler<AddPositionsToMeasurementUnitCommand>
{
    public async Task Handle(
        AddPositionsToMeasurementUnitCommand request,
        CancellationToken cancellationToken)
    {
        var measurementUnit = await GetMeasurementUnitAsync(request, cancellationToken);

        measurementUnit.AddPositions(new AddPositionsToMeasurementUnitParameters
        {
            MeasurementUnitPositions = request.BodyDto.MeasurementUnitPositions
                .Select(static mup => new AddPositionsToMeasurementUnitParameters.MeasurementUnitPosition
                {
                    Value = mup.Value
                })
        });
        await context.SaveChangesAsync(cancellationToken);
    }

    private Task<MeasurementUnit> GetMeasurementUnitAsync(AddPositionsToMeasurementUnitCommand request,
        CancellationToken cancellationToken)
    {
        return context.MeasurementUnits
            .AsTracking()
            .Include(static mu => mu.MeasurementUnitPositions)
            .SingleAsync(
                mu => mu.Id == request.RouteDto.MeasurementUnitId,
                cancellationToken);
    }
}