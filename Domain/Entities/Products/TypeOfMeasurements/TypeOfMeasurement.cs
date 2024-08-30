// ReSharper disable ConvertToAutoPropertyWithPrivateSetter

using Domain.Entities.Products.TypeOfMeasurements.Parameters;

namespace Domain.Entities.Products.TypeOfMeasurements;

public sealed class TypeOfMeasurement
{
    private string _title = default!;

    private TypeOfMeasurement()
    {
    }

    public TypeOfMeasurement(CreateTypeOfMeasurementParameters parameters) : this()
    {
        SetTitle(new SetTypeOfMeasurementTitleParameters
        {
            Title = parameters.Title
        });
    }
    
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Title => _title;

    public void SetTitle(SetTypeOfMeasurementTitleParameters parameters)
    {
        _title = parameters.Title;
    }
}