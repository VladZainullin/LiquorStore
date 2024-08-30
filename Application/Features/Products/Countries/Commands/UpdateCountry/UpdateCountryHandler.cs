using Application.Contracts.Features.Products.Countries.Commands.UpdateCountry;
using Domain.Entities.Products.Countries;
using Domain.Entities.Products.Countries.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Countries.Commands.UpdateCountry;

file sealed class UpdateCountryHandler(IAppDbContext context) : IRequestHandler<UpdateCountryCommand>
{
    public async Task Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await GetCountryAsync(request.RouteDto.CountryId, cancellationToken);

        country?.SetTitle(new SetCountryTitleParameters
        {
            Title = request.BodyDto.Title
        });

        await context.SaveChangesAsync(cancellationToken);
    }

    private Task<Country?> GetCountryAsync(
        Guid countryId,
        CancellationToken cancellationToken)
    {
        return context.Countries
            .AsTracking()
            .Where(c => c.Id == countryId)
            .SingleOrDefaultAsync(cancellationToken);
    }
}