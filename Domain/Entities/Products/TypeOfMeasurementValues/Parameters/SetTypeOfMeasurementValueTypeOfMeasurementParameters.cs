using Domain.Entities.Products.TypeOfMeasurements;

namespace Domain.Entities.Products.TypeOfMeasurementValues.Parameters;

public sealed class SetTypeOfMeasurementValueTypeOfMeasurementParameters
{
    public required TypeOfMeasurement TypeOfMeasurement { get; init; }
}