using MediatR;

namespace Application.Contracts.Features.Countries.Queries.GetCountry;

public sealed record GetCountryCommand(GetCountryRequestRouteDto RouteDto) : 
    IRequest<GetCountryResponseDto>;