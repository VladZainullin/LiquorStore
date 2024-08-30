// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Products.Countries.Queries.GetCountry;

public sealed class GetCountryRequestRouteDto
{
    public required Guid CountryId { get; init; }
}