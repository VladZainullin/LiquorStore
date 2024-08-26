using Application.Contracts.Features.Countries.Commands.CreateCountry;
using Application.Contracts.Features.Countries.Queries.GetCountry;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/countries")]
public sealed class CountryController : AppController
{
    [HttpGet("{countryId:guid}")]
    public async Task<ActionResult<CreateCountryResponseDto>> GetCountryAsync(
        [FromRoute] GetCountryRequestRouteDto routeDto,
        CancellationToken cancellationToken)
    {
        var country = await Sender.Send(new GetCountryCommand(routeDto), cancellationToken);
        return Ok(country);
    }
    
    [HttpPost]
    public async Task<ActionResult<CreateCountryResponseDto>> CreateCountryAsync(
        [FromBody] CreateCountryRequestBodyDto bodyDto,
        CancellationToken cancellationToken)
    {
        var countryId = await Sender.Send(new CreateCountryCommand(bodyDto), cancellationToken);
        return StatusCode(StatusCodes.Status201Created, countryId);
    }
}