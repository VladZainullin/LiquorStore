using Application.Contracts.Features.Products.Countries.Queries.GetCountry;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Countries.Queries.GetCountry;

file sealed class GetCountryHandler(IAppDbContext context) : 
    IRequestHandler<GetCountryCommand, GetCountryResponseDto>
{
    public Task<GetCountryResponseDto> Handle(
        GetCountryCommand request,
        CancellationToken cancellationToken)
    {
        return context.Countries
            .Where(c => c.Id == request.RouteDto.CountryId)
            .Select(static c => new GetCountryResponseDto
            {
                Title = c.Title
            })
            .SingleAsync(cancellationToken);
    }
}