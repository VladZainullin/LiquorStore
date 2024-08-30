// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Domain.Entities.Products.Countries.Parameters;

public sealed class CreateCountryParameters
{
    public required string Title { get; init; }
}