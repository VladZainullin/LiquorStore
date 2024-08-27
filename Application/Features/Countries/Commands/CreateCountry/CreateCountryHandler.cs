using Application.Contracts.Features.Countries.Commands.CreateCountry;
using Domain.Entities.Countries;
using Domain.Entities.Countries.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Countries.Commands.CreateCountry;

file sealed class CreateCountryHandler(IDbContext context)
    : IRequestHandler<CreateCountryCommand, CreateCountryResponseDto>
{

    public async Task<CreateCountryResponseDto> Handle(
        CreateCountryCommand request,
        CancellationToken cancellationToken)
    {
        var countryWithSomeTitle = await GetCountryAsync(request.BodyDto, cancellationToken);

        if (!ReferenceEquals(countryWithSomeTitle, default))
            return new CreateCountryResponseDto
            {
                Id = countryWithSomeTitle.Id
            };
        
        var country = new Country(new CreateCountryParameters
        {
            Title = request.BodyDto.Title
        });
        
        context.Countries.Add(country);
        await context.SaveChangesAsync(cancellationToken); 
            
        return new CreateCountryResponseDto
        {
            Id = country.Id
        };

    }

    private Task<Country?> GetCountryAsync(
        CreateCountryRequestBodyDto bodyDto,
        CancellationToken cancellationToken)
    {
        return context.Countries
            .AsNoTracking()
            .Where(c => c.Title == bodyDto.Title)
            .SingleOrDefaultAsync(cancellationToken);
    }
}