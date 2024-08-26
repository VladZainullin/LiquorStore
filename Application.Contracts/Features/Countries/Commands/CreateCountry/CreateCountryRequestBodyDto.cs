namespace Application.Contracts.Features.Countries.Commands.CreateCountry;

public sealed class CreateCountryRequestBodyDto
{
    public required string Title { get; init; }
}