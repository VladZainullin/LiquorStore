namespace Application.Contracts.Features.Products.Countries.Queries.GetCountries;

public sealed class GetCountriesResponseDto
{
    public required IReadOnlyCollection<CountryDto> Countries { get; init; }

    public sealed class CountryDto
    {
        public required Guid Id { get; init; }

        public required string Title { get; init; }
    }
}