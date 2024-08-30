namespace Application.Contracts.Features.Products.Countries.Commands.DeleteCountry;

public sealed class DeleteCountryRequestRouteDto
{
    public required Guid CountryId { get; init; }
}