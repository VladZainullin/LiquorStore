using Domain.Abstractions;
using Domain.MeasurementUnitPositions;
using Domain.MeasurementUnitPositions.Parameters;
using Domain.MeasurementUnits.Parameters;

namespace Domain.MeasurementUnits;

public sealed class MeasurementUnit : IRemovable<RemoveMeasurementUnitParameters>
{
    public Guid _id = Guid.NewGuid();
    
    private string _title = default!;
    
    private DateTimeOffset? _removed_at;

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

    public string Title => _title;

    public void SetTitle(SetMeasurementUnitTitleParameters parameters)
    {
        _title = parameters.Title;
    }

    public DateTimeOffset? RemovedAt => _removed_at;
    
    public bool IsRemove => _removed_at != default;
    
    public void Remove(RemoveMeasurementUnitParameters parameters)
    {
        _removed_at = parameters.TimeProvider.GetUtcNow();

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

    public void AddMeasurementUnits(AddMeasurementUnitPositionToMeasurementUnitParameters parameters)
    {
        _measurementUnitPositions.AddRange(parameters.MeasurementUnitPositions);
    }

    public void RemoveMeasurementUnits(RemoveMeasurementUnitPositionsFromMeasurementUnitParameters parameters)
    {
        foreach (var measurementUnitPosition in parameters.MeasurementUnitPositions)
        {
            measurementUnitPosition.Remove(new RemoveMeasurementUnitPositionParameters
            {
                TimeProvider = parameters.TimeProvider
            });
        }
    }
}