using Domain.Abstractions;
using Domain.MeasurementUnitPositions.Parameters;
using Domain.MeasurementUnits;

namespace Domain.MeasurementUnitPositions;

public sealed class MeasurementUnitPosition : 
    IRemovable<RemoveMeasurementUnitPositionParameters>
{
    private Guid _id = Guid.NewGuid();
    
    private string _value = default!;

    private MeasurementUnit _measurementUnit = default!;

    private DateTimeOffset? _removed_at;
    
    private MeasurementUnitPosition()
    {
    }

    public MeasurementUnitPosition(CreateMeasurementUnitPositionParameters positionParameters) : this()
    {
        SetValue(new SetMeasurementUnitPositionValueParameters
        {
            Value = positionParameters.Title
        });
        
        SetMeasurementUnit(new SetMeasurementUnitPositionMeasurementUnitParameters
        {
            MeasurementUnit = positionParameters.MeasurementUnit
        });
    }

    public void SetValue(SetMeasurementUnitPositionValueParameters parameters)
    {
        _value = parameters.Value;
    }

    public void SetMeasurementUnit(SetMeasurementUnitPositionMeasurementUnitParameters parameters)
    {
        _measurementUnit = parameters.MeasurementUnit;
    }

    public DateTimeOffset? RemovedAt => _removed_at;

    public bool IsRemove => _removed_at != default;

    public void Remove(RemoveMeasurementUnitPositionParameters parameters)
    {
        _removed_at = parameters.TimeProvider.GetUtcNow();
    }
}