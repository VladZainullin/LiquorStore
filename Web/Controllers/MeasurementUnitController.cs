using Application.Contracts.Features.MeasurementUnits.Commands.AddPositionsToMeasurementUnit;
using Application.Contracts.Features.MeasurementUnits.Commands.CreateMeasurementUnit;
using Application.Contracts.Features.MeasurementUnits.Commands.RemoveMeasurementUnits;
using Application.Contracts.Features.MeasurementUnits.Commands.RemovePositionsFromMeasurementUnit;
using Application.Contracts.Features.MeasurementUnits.Commands.UpdateMeasurementUnit;
using Application.Contracts.Features.MeasurementUnits.Commands.UpdateMeasurementUnitPosition;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/measurement-units")]
public sealed class MeasurementUnitController : AppController
{
    [HttpPost]
    public async Task<IActionResult> CreateMeasurementUnitAsync([FromBody] CreateMeasurementUnitRequestBodyDto bodyDto)
    {
        return StatusCode(
            StatusCodes.Status201Created, 
            await Sender.Send(new CreateMeasurementUnitCommand(bodyDto), HttpContext.RequestAborted));
    }
    
    [HttpPost("{measurementUnitId:guid}/positions")]
    public async Task<IActionResult> AddMeasurementUnitPositionsAsync(
        [FromRoute] AddPositionsToMeasurementUnitRequestRouteDto routeDto,
        [FromBody] AddPositionsToMeasurementUnitRequestBodyDto bodyDto)
    {
        await Sender.Send(new AddPositionsToMeasurementUnitCommand(routeDto, bodyDto), HttpContext.RequestAborted);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveMeasurementUnitsAsync([FromBody] RemoveMeasurementUnitsRequestBodyDto bodyDto)
    {
        await Sender.Send(new RemoveMeasurementUnitsCommand(bodyDto), HttpContext.RequestAborted);
        return NoContent();
    }
    
    [HttpDelete("{measurementUnitId:guid}/positions")]
    public async Task<IActionResult> RemoveMeasurementUnitPositionsAsync(
        [FromRoute] RemovePositionsFromMeasurementUnitRequestRouteDto routeDto,
        [FromBody] RemovePositionsToMeasurementUnitRequestBodyDto bodyDto)
    {
        await Sender.Send(new RemovePositionsFromMeasurementUnitCommand(routeDto, bodyDto), HttpContext.RequestAborted);
        return NoContent();
    }

    [HttpPut("{measurementUnitId:guid}")]
    public async Task<IActionResult> UpdateMeasurementUnitAsync(
        [FromRoute] UpdateMeasurementUnitRequestRouteDto routeDto,
        [FromBody] UpdateMeasurementUnitRequestBodyDto bodyDto)
    {
        await Sender.Send(new UpdateMeasurementUnitCommand(routeDto, bodyDto), HttpContext.RequestAborted);
        return NoContent();
    }

    [HttpPut("{measurementUnitId:guid}/positions/{measurementUnitPositionId:guid}")]
    public async Task<IActionResult> UpdateMeasurementUnitPositionAsync(
        [FromRoute] UpdateMeasurementUnitPositionRequestRouteDto routeDto,
        [FromBody] UpdateMeasurementUnitPositionRequestBodyDto bodyDto)
    {
        await Sender.Send(new UpdateMeasurementUnitPositionCommand(routeDto, bodyDto), HttpContext.RequestAborted);
        return NoContent();
    }
}