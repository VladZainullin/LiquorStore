using Application.Contracts.Features.Products.Countries.Commands.CreateCountry;
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
}