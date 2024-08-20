// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Countries.Parameters;

public sealed class CreateCountryParameters
{
    public required string Title { get; init; }
}