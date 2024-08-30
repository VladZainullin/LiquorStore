using MediatR;

namespace Application.Contracts.Features.Products.Countries.Commands.DeleteCountry;

public sealed record DeleteCountryCommand(DeleteCountryRequestRouteDto RouteDto) : IRequest;