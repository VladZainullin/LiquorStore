using Application.Contracts.Features.Products.Countries.Commands.CreateCountry;
using Application.Contracts.Features.Products.Countries.Commands.DeleteCountry;
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

    [HttpDelete("{countryId:guid}")]
    public async Task<NoContentResult> DeleteCountryAsync(
        [FromRoute] DeleteCountryRequestRouteDto routeDto,
        CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteCountryCommand(routeDto), cancellationToken);

        return NoContent();
    }
}