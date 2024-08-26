using Application.Contracts.Features.Countries.Commands.CreateCountry;
using Domain.Entities.Countries;
using Domain.Entities.Countries.Parameters;
using MediatR;
using Persistence.Contracts;

namespace Application.Features.Countries.Commands.CreateCountry;

file sealed class CreateCountryHandler(IDbContext context)
    : IRequestHandler<CreateCountryCommand, CreateCountryResponseDto>
{

    public async Task<CreateCountryResponseDto> Handle(
        CreateCountryCommand request,
        CancellationToken cancellationToken)
    {
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
}