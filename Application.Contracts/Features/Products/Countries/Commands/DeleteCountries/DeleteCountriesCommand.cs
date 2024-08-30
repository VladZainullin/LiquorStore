using MediatR;

namespace Application.Contracts.Features.Products.Countries.Commands.DeleteCountries;

public sealed record DeleteCountriesCommand(DeleteCountriesRequestBodyDto BodyDto) : IRequest;