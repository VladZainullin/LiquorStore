using Application.Contracts.Features.Products.Countries.Commands.CreateCountry;
using Domain.Entities.Products.Countries;
using Domain.Entities.Products.Countries.Parameters;
using MediatR;
using Persistence.Contracts;

namespace Application.Features.Products.Countries.Commands.CreateCountry;

file sealed class CreateCountryHandler(IAppDbContext context) : 
    IRequestHandler<CreateCountryCommand, CreateCountryResponseDto>
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