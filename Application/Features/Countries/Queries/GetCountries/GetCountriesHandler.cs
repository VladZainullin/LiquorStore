using Application.Contracts.Features.Countries.Queries.GetCountries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Countries.Queries.GetCountries;

file sealed class GetCountriesHandler(IDbContext context) : 
    IRequestHandler<GetCountriesQuery, GetCountriesResponseDto>
{
    public async Task<GetCountriesResponseDto> Handle(
        GetCountriesQuery request,
        CancellationToken cancellationToken)
    {
        var countries = await GetCountriesAsync(request.QueryDto, cancellationToken);

        return new GetCountriesResponseDto
        {
            Countries = countries
        };
    }

    private Task<List<GetCountriesResponseDto.CountryDto>> GetCountriesAsync(
        GetCountriesRequestQueryDto queryDto,
        CancellationToken cancellationToken)
    {
        var queryable = context.Countries.AsNoTracking();
        
        if (queryDto.Search != null)
        {
            queryable = queryable.Where(c => c.Title.Contains(queryDto.Search));
        }
        
        if (queryDto.Skip != null && queryDto.Skip != 0)
        {
            queryable = queryable.Skip(queryDto.Skip.Value);
        }
        
        if (queryDto.Take != null && queryDto.Take != 0)
        {
            queryable = queryable.Take(queryDto.Take.Value);
        }

        return queryable
            .Select(static c => new GetCountriesResponseDto.CountryDto
            {
                Id = c.Id,
                Title = c.Title
            })
            .ToListAsync(cancellationToken);
    }
}