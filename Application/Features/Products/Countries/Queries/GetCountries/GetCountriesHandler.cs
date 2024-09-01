using Application.Contracts.Features.Products.Countries.Queries.GetCountries;
using Domain.Entities.Products.Countries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Countries.Queries.GetCountries;

file sealed class GetCountriesHandler(IAppDbContext context) : 
    IRequestHandler<GetCountriesQuery, GetCountriesResponseDto>
{
    public async Task<GetCountriesResponseDto> Handle(
        GetCountriesQuery request,
        CancellationToken cancellationToken)
    {
        var queryable = CreateQueryable(request);

        var countries = await queryable
            .Select(static c => new GetCountriesResponseDto.CountryDto
            {
                Id = c.Id,
                Title = c.Title.Value
            })
            .ToListAsync(cancellationToken);

        return new GetCountriesResponseDto
        {
            Countries = countries
        };
    }

    private IQueryable<Country> CreateQueryable(GetCountriesQuery request)
    {
        var queryable = context.Countries.AsNoTracking();

        if (request.QueryDto.Skip.HasValue && request.QueryDto.Skip != 0)
        {
            queryable = queryable.Skip(request.QueryDto.Skip.Value);
        }
        
        if (request.QueryDto.Take.HasValue && request.QueryDto.Take != 0)
        {
            queryable = queryable.Take(request.QueryDto.Take.Value);
        }

        return queryable;
    }
}