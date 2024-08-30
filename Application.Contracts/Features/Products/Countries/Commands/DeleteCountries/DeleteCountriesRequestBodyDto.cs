namespace Application.Contracts.Features.Products.Countries.Commands.DeleteCountries;

public sealed class DeleteCountriesRequestBodyDto
{
    public required IReadOnlyCollection<Guid> Countries { get; init; }
}