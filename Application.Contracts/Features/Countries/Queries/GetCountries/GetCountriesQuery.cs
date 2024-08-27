using MediatR;

namespace Application.Contracts.Features.Countries.Queries.GetCountries;

public sealed record GetCountriesQuery(GetCountriesRequestQueryDto QueryDto) : 
    IRequest<GetCountriesResponseDto>;