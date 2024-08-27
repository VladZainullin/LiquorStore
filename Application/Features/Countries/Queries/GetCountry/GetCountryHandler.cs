using Application.Contracts.Features.Countries.Queries.GetCountry;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Countries.Queries.GetCountry;

file sealed class GetCountryHandler(IDbContext context) :
    IRequestHandler<GetCountryQuery, GetCountryResponseDto>
{
    public Task<GetCountryResponseDto> Handle(
        GetCountryQuery request,
        CancellationToken cancellationToken)
    {
        return context.Countries
            .AsNoTracking()
            .Where(c => c.Id == request.RouteDto.CountryId)
            .Select(static c => new GetCountryResponseDto
            {
                Id = c.Id,
                Title = c.Title
            })
            .SingleAsync(cancellationToken);
    }
}