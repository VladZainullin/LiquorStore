using Domain.Entities.Products.TypeOfMeasurements;
using Domain.Entities.Products.TypeOfMeasurementValues.Parameters;

// ReSharper disable ConvertToAutoPropertyWithPrivateSetter

namespace Domain.Entities.Products.TypeOfMeasurementValues;

public sealed class TypeOfMeasurementValue
{
    private string _value = default!;
    private TypeOfMeasurement _typeOfMeasurement = default!;

    private TypeOfMeasurementValue()
    {
    }

    public TypeOfMeasurementValue(CreateTypeOfMeasurementValueParameters parameters) : this()
    {
        SetValue(new SetTypeOfMeasurementValueValueParameters
        {
            Value = parameters.Value
        });
        
        SetTypeOfMeasurement(new SetTypeOfMeasurementValueTypeOfMeasurementParameters
        {
            TypeOfMeasurement = parameters.TypeOfMeasurement
        });
    }
    
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Value => _value;

    public void SetValue(SetTypeOfMeasurementValueValueParameters parameters)
    {
        _value = parameters.Value;
    }

    public TypeOfMeasurement TypeOfMeasurement => _typeOfMeasurement;

    public void SetTypeOfMeasurement(SetTypeOfMeasurementValueTypeOfMeasurementParameters parameters)
    {
        _typeOfMeasurement = parameters.TypeOfMeasurement;
    }
}