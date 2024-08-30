using MediatR;

namespace Application.Contracts.Features.Products.Countries.Commands.UpdateCountry;

public sealed record UpdateCountryCommand(
    UpdateCountryRequestRouteDto RouteDto,
    UpdateCountryRequestBodyDto BodyDto) : IRequest;