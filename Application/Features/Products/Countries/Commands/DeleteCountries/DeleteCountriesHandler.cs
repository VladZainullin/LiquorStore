using Application.Contracts.Features.Products.Countries.Commands.DeleteCountries;
using Domain.Entities.Products.Countries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Countries.Commands.DeleteCountries;

file sealed class DeleteCountriesHandler(IAppDbContext context) : 
    IRequestHandler<DeleteCountriesCommand>
{
    public async Task Handle(DeleteCountriesCommand request, CancellationToken cancellationToken)
    {
        var countries = await GetCountriesAsync(
            request.BodyDto.Countries,
            cancellationToken);
        
        context.Countries.RemoveRange(countries);
        await context.SaveChangesAsync(cancellationToken);
    }

    private Task<List<Country>> GetCountriesAsync(
        IReadOnlyCollection<Guid> countries,
        CancellationToken cancellationToken)
    {
        return context.Countries
            .AsTracking()
            .Where(c => countries.Contains(c.Id))
            .ToListAsync(cancellationToken);
    }
}