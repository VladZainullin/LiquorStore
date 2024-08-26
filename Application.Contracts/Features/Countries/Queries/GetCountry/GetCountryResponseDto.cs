namespace Application.Contracts.Features.Countries.Queries.GetCountry;

public sealed class GetCountryResponseDto
{
    public required Guid Id { get; init; }

    public required string Title { get; init; }
}