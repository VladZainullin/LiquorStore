using MediatR;

namespace Application.Contracts.Features.Countries.Queries.GetCountry;

public sealed record GetCountryQuery(GetCountryRequestRouteDto RouteDto) : 
    IRequest<GetCountryResponseDto>;