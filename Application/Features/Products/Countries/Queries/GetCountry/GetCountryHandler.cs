using Application.Contracts.Features.Products.Countries.Queries.GetCountry;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Countries.Queries.GetCountry;

file sealed class GetCountryHandler(IDbContext context) : 
    IRequestHandler<GetCountryQuery, GetCountryResponseDto>
{
    public Task<GetCountryResponseDto> Handle(
        GetCountryQuery request,
        CancellationToken cancellationToken)
    {
        return context.Countries
            .Where(c => c.Id == request.RouteDto.CountryId)
            .Select(static c => new GetCountryResponseDto
            {
                Title = c.Title.Value
            })
            .SingleAsync(cancellationToken);
    }
}