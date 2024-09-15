using Domain.MeasurementUnitPositions.Parameters;
using Domain.MeasurementUnits;

namespace Domain.MeasurementUnitPositions;

public sealed class MeasurementUnitPosition
{
    private Guid _id;
    
    private string _value = default!;
    
    private MeasurementUnit _measurementUnit = default!;
    
    private MeasurementUnitPosition()
    {
    }

    internal MeasurementUnitPosition(CreateMeasurementUnitPositionParameters positionParameters) : this()
    {
        _id = Guid.NewGuid();
        
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

    private void SetValue(SetMeasurementUnitPositionValueParameters parameters)
    {
        _value = parameters.Value;
    }
    
    public MeasurementUnit MeasurementUnit => _measurementUnit;

    private void SetMeasurementUnit(SetMeasurementUnitPositionMeasurementUnitParameters parameters)
    {
        _measurementUnit = parameters.MeasurementUnit;
    }
}