using MediatR;

namespace Application.Contracts.Features.Products.Countries.Queries.GetCountry;

public sealed record GetCountryQuery(GetCountryRequestRouteDto RouteDto) : 
    IRequest<GetCountryResponseDto>;