// ReSharper disable UnusedAutoPropertyAccessor.Global

using Domain.Entities.Products.TypeOfMeasurements;

namespace Domain.Entities.Products.TypeOfMeasurementValues.Parameters;

public sealed class CreateTypeOfMeasurementValueParameters
{
    public required string Value { get; init; }

    public required TypeOfMeasurement TypeOfMeasurement { get; init; }
}