using MediatR;

namespace Application.Contracts.Features.Products.Countries.Commands.CreateCountry;

public sealed record CreateCountryCommand(CreateCountryRequestBodyDto BodyDto) :
    IRequest<CreateCountryResponseDto>;