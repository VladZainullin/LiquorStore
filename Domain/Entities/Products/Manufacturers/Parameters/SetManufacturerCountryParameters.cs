// ReSharper disable UnusedAutoPropertyAccessor.Global
using Domain.Entities.Products.Countries;

namespace Domain.Entities.Products.Manufacturers.Parameters;

public sealed class SetManufacturerCountryParameters
{
    public required Country Country { get; init; }
}