// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Products.Countries.Commands.UpdateCountry;

public sealed class UpdateCountryRequestBodyDto
{
    public required string Title { get; init; }
}