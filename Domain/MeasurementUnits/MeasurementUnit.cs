using Domain.Abstractions;
using Domain.MeasurementUnitPositions;
using Domain.MeasurementUnitPositions.Parameters;
using Domain.MeasurementUnits.Parameters;

namespace Domain.MeasurementUnits;

public sealed class MeasurementUnit : IRemovable<RemoveMeasurementUnitParameters>
{
    private Guid _id = Guid.NewGuid();
    
    private string _title = default!;
    
    private DateTimeOffset? _removedAt;

    private readonly List<MeasurementUnitPosition> _measurementUnitPositions = [];
    
    private MeasurementUnit()
    {
    }

    public MeasurementUnit(CreateMeasurementUnitParameters parameters) : this()
    {
        SetTitle(new SetMeasurementUnitTitleParameters
        {
            Title = parameters.Title
        });
    }

    public Guid Id => _id;

    public string Title => _title;

    public void SetTitle(SetMeasurementUnitTitleParameters parameters)
    {
        _title = parameters.Title;
    }

    public DateTimeOffset? RemovedAt => _removedAt;
    
    public bool IsRemove => _removedAt != default;
    
    public void Remove(RemoveMeasurementUnitParameters parameters)
    {
        _removedAt = parameters.TimeProvider.GetUtcNow();

        foreach (var measurementUnitPosition in _measurementUnitPositions)
        {
            measurementUnitPosition.Remove(new RemoveMeasurementUnitPositionParameters
            {
                TimeProvider = parameters.TimeProvider
            });
        }
    }

    public IReadOnlyCollection<MeasurementUnitPosition> MeasurementUnitPositions =>
        _measurementUnitPositions.AsReadOnly();

    public void AddPositions(AddPositionsToMeasurementUnitParameters parameters)
    {
        var resultMeasurementUnitPositions = parameters.MeasurementUnitPositions
            .DistinctBy(mup => mup.Value)
            .Except(_measurementUnitPositions);
        
        _measurementUnitPositions.AddRange(resultMeasurementUnitPositions);
    }

    public void AddPositions()
    {
        
    }

    public void RemovePositions(RemovePositionsFromMeasurementUnitParameters parameters)
    {
        foreach (var measurementUnitPosition in parameters.MeasurementUnitPositions)
        {
            measurementUnitPosition.Remove(new RemoveMeasurementUnitPositionParameters
            {
                TimeProvider = parameters.TimeProvider
            });
        }
    }

    public void Restore()
    {
        _removedAt = default;
        
        foreach (var measurementUnitPosition in _measurementUnitPositions)
        {
            measurementUnitPosition.Restore();
        }
    }
}