using MediatR;

namespace Application.Contracts.Features.Products.Countries.Queries.GetCountry;

public sealed record GetCountryCommand(GetCountryRequestRouteDto RouteDto) : 
    IRequest<GetCountryResponseDto>;