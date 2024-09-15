using Domain.MeasurementUnitPositions.Parameters;
using Domain.MeasurementUnits;

namespace Domain.MeasurementUnitPositions;

public sealed class MeasurementUnitPosition
{
    private Guid _id = Guid.NewGuid();
    
    private string _value = default!;

    private MeasurementUnit _measurementUnit = default!;

    private DateTimeOffset? _removedAt;
    
    private MeasurementUnitPosition()
    {
    }

    public MeasurementUnitPosition(CreateMeasurementUnitPositionParameters positionParameters) : this()
    {
        SetValue(new SetMeasurementUnitPositionValueParameters
        {
            Value = positionParameters.Value
        });
        
        SetMeasurementUnit(new SetMeasurementUnitPositionMeasurementUnitParameters
        {
            MeasurementUnit = positionParameters.MeasurementUnit
        });
    }

    public Guid Id => _id;

    public string Value => _value;
    
    public void SetValue(SetMeasurementUnitPositionValueParameters parameters)
    {
        _value = parameters.Value;
    }

    public MeasurementUnit MeasurementUnit => _measurementUnit;

    public void SetMeasurementUnit(SetMeasurementUnitPositionMeasurementUnitParameters parameters)
    {
        _measurementUnit = parameters.MeasurementUnit;
    }

    public DateTimeOffset? RemovedAt => _removedAt;

    public bool IsRemove => _removedAt != default;

    public void Remove(RemoveMeasurementUnitPositionParameters parameters)
    {
        _removedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void Restore()
    {
        _removedAt = default;
    }
}