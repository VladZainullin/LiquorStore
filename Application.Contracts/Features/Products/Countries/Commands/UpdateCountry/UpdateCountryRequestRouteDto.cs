// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Products.Countries.Commands.UpdateCountry;

public sealed class UpdateCountryRequestRouteDto
{
    public required Guid CountryId { get; init; }
}