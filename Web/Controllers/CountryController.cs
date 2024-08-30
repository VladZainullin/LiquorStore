using Application.Contracts.Features.Products.Countries.Commands.CreateCountry;
using Application.Contracts.Features.Products.Countries.Commands.DeleteCountries;
using Application.Contracts.Features.Products.Countries.Commands.DeleteCountry;
using Application.Contracts.Features.Products.Countries.Commands.UpdateCountry;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/countries")]
public sealed class CountryController : AppController
{
    [HttpPost]
    public async Task<ActionResult<CreateCountryResponseDto>> CreateCountryAsync(
        [FromBody] CreateCountryRequestBodyDto bodyDto,
        CancellationToken cancellationToken)
    {
        var response = await Sender.Send(new CreateCountryCommand(bodyDto), cancellationToken);

        return StatusCode(StatusCodes.Status201Created, response);
    }

    [HttpPut]
    public async Task<NoContentResult> UpdateCountryAsync(
        [FromRoute] UpdateCountryRequestRouteDto routeDto,
        [FromBody] UpdateCountryRequestBodyDto bodyDto,
        CancellationToken cancellationToken)
    {
        await Sender.Send(new UpdateCountryCommand(routeDto, bodyDto), cancellationToken);

        return NoContent();
    }

    [HttpDelete("{countryId:guid}")]
    public async Task<NoContentResult> DeleteCountryAsync(
        [FromRoute] DeleteCountryRequestRouteDto routeDto,
        CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteCountryCommand(routeDto), cancellationToken);

        return NoContent();
    }
    
    [HttpDelete]
    public async Task<NoContentResult> DeleteCountriesAsync(
        [FromRoute] DeleteCountriesRequestBodyDto bodyDto,
        CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteCountriesCommand(bodyDto), cancellationToken);

        return NoContent();
    }
}