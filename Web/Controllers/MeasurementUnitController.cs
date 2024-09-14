using Application.Contracts.Features.MeasurementUnits.Commands.CreateMeasurementUnit;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/measurement-units")]
public sealed class MeasurementUnitController : AppController
{
    [HttpPost]
    public async Task<IActionResult> CreateMeasurementUnitAsync(
        CreateMeasurementUnitRequestBodyDto bodyDto,
        CancellationToken cancellationToken)
    {
        return StatusCode(
            StatusCodes.Status201Created, 
            await Sender.Send(new CreateMeasurementUnitCommand(bodyDto), cancellationToken));
    }
}