using Application.Contracts.Features.Products.Countries.Commands.DeleteCountry;
using Domain.Entities.Products.Countries;
using Domain.Entities.Products.Countries.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Countries.Commands.DeleteCountry;

file sealed class DeleteCountryHandler(IAppDbContext context) : IRequestHandler<DeleteCountryCommand>
{
    public async Task Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await GetCountryAsync(
            request.RouteDto.CountryId,
            cancellationToken);
        if (ReferenceEquals(country, default)) return;
        
        context.Countries.Remove(country);
        await context.SaveChangesAsync(cancellationToken);
    }

    private Task<Country?> GetCountryAsync(Guid id, CancellationToken cancellationToken)
    {
        return context.Countries
            .Where(c => c.Id == id)
            .SingleOrDefaultAsync(cancellationToken);
    }
}