namespace Application.Contracts.Features.Products.Countries.Queries.GetCountries;

public sealed class GetCountriesRequestQueryDto
{
    public int? Skip { get; init; }

    public int? Take { get; init; }
}