// ReSharper disable UnusedAutoPropertyAccessor.Global
using Domain.Entities.Products.Manufacturers;

namespace Domain.Entities.Products.Countries.Parameters;

public sealed class AddManufacturersParameters
{
    public required IEnumerable<Manufacturer> Manufacturers { get; init; }
}