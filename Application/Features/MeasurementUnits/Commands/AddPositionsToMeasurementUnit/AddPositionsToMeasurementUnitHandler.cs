using Application.Contracts.Features.MeasurementUnits.Commands.AddPositionsToMeasurementUnit;
using Domain.MeasurementUnitPositions;
using Domain.MeasurementUnitPositions.Parameters;
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

        var addableMeasurementUnitPositions = 
            CreateMeasurementUnitPositionsAsync(request.BodyDto.Values, measurementUnit);
        
        measurementUnit.AddPositions(new AddPositionsToMeasurementUnitParameters
        {
            MeasurementUnitPositions = addableMeasurementUnitPositions
        });

        await context.SaveChangesAsync(cancellationToken);
    }

    private Task<MeasurementUnit> GetMeasurementUnitAsync(AddPositionsToMeasurementUnitCommand request, CancellationToken cancellationToken)
    {
        return context.MeasurementUnits
            .AsTracking()
            .Include(static mu => mu.MeasurementUnitPositions)
            .SingleAsync(
                mu => mu.Id == request.RouteDto.MeasurementUnitId,
                cancellationToken);
    }

    private static IEnumerable<MeasurementUnitPosition> CreateMeasurementUnitPositionsAsync(
        IEnumerable<string> values,
        MeasurementUnit measurementUnit)
    {
        return values.Select(value => new MeasurementUnitPosition(new CreateMeasurementUnitPositionParameters
        {
            Value = value,
            MeasurementUnit = measurementUnit
        }));
    }
}