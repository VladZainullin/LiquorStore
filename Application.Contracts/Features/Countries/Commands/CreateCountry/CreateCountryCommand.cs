using MediatR;

namespace Application.Contracts.Features.Countries.Commands.CreateCountry;

public sealed record CreateCountryCommand(CreateCountryRequestBodyDto BodyDto) : 
    IRequest<CreateCountryResponseDto>;