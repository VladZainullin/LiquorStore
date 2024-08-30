using Application.Contracts.Features.Products.Countries.Commands.DeleteCountry;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Countries.Commands.DeleteCountry;

file sealed class DeleteCountryHandler(IAppDbContext context) : IRequestHandler<DeleteCountryCommand>
{
    public async Task Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await context.Countries.SingleOrDefaultAsync(cancellationToken);
        if (ReferenceEquals(country, default)) return;
        
        context.Countries.Remove(country);
        await context.SaveChangesAsync(cancellationToken);
    }
}