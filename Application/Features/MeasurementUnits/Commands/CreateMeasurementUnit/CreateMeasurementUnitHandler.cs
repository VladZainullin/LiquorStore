using Application.Contracts.Features.MeasurementUnits.Commands.CreateMeasurementUnit;
using Domain.MeasurementUnits;
using Domain.MeasurementUnits.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.MeasurementUnits.Commands.CreateMeasurementUnit;

file sealed class CreateMeasurementUnitHandler(IDbContext context)
    : IRequestHandler<CreateMeasurementUnitCommand, CreateMeasurementUnitResponseDto>
{
    public async Task<CreateMeasurementUnitResponseDto> Handle(
        CreateMeasurementUnitCommand request,
        CancellationToken cancellationToken)
    {
        var existingMeasurementUnit = await GetMeasurementUnitAsync(request, cancellationToken);

        if (ReferenceEquals(existingMeasurementUnit, default))
        {
            var measurementUnit = new MeasurementUnit(new CreateMeasurementUnitParameters
            {
                Title = request.BodyDto.Title,
            });
            measurementUnit.AddPositions(new AddPositionsToMeasurementUnitParameters
            {
                MeasurementUnitPositions = request.BodyDto.MeasurementUnitPositions
                    .Select(s => new AddPositionsToMeasurementUnitParameters.MeasurementUnitPosition
                    {
                        Value = s.Value
                    })
            });

            context.MeasurementUnits.Add(measurementUnit);
            await context.SaveChangesAsync(cancellationToken);

            return new CreateMeasurementUnitResponseDto
            {
                MeasurementUnitId = measurementUnit.Id
            };
        }

        var measurementUnitPositions = existingMeasurementUnit.MeasurementUnitPositions
            .ExceptBy(
                request.BodyDto.MeasurementUnitPositions
                    .Select(static m => m.Value),
                m => m.Value);
        
        existingMeasurementUnit.RemovePositions(new RemovePositionsFromMeasurementUnitParameters
        {
            MeasurementUnitPositions = measurementUnitPositions
        });

        existingMeasurementUnit.AddPositions(new AddPositionsToMeasurementUnitParameters
        {
            MeasurementUnitPositions = request.BodyDto.MeasurementUnitPositions
                .Select(s => new AddPositionsToMeasurementUnitParameters.MeasurementUnitPosition
                {
                    Value = s.Value
                })
        });

        await context.SaveChangesAsync(cancellationToken);
        
        return new CreateMeasurementUnitResponseDto
        {
            MeasurementUnitId = existingMeasurementUnit.Id
        };
    }

    private Task<MeasurementUnit?> GetMeasurementUnitAsync(CreateMeasurementUnitCommand request,
        CancellationToken cancellationToken)
    {
        return context.MeasurementUnits
            .Include(static mu => mu.MeasurementUnitPositions)
            .AsTracking()
            .SingleOrDefaultAsync(mu => mu.Title == request.BodyDto.Title, cancellationToken);
    }
}