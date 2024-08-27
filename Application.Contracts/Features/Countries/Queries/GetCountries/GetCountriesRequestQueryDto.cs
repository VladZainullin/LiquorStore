// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Application.Contracts.Features.Countries.Queries.GetCountries;

public sealed class GetCountriesRequestQueryDto
{
    public int? Skip { get; init; }

    public int? Take { get; init; }

    public string? Search { get; init; }
}