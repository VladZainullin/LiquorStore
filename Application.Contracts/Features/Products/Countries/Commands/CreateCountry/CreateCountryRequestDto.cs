// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Application.Contracts.Features.Products.Countries.Commands.CreateCountry;

public sealed class CreateCountryRequestBodyDto
{
    public required string Title { get; init; }
}