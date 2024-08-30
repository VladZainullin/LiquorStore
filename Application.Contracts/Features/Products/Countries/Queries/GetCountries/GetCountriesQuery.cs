using MediatR;

namespace Application.Contracts.Features.Products.Countries.Queries.GetCountries;

public sealed record GetCountriesQuery(GetCountriesRequestQueryDto QueryDto) : IRequest<GetCountriesResponseDto>;