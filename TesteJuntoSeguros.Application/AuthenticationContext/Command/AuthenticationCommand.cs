using TesteJuntoSeguros.Domain.AuthenticationContext.Dtos;
using MediatR;

namespace TesteJuntoSeguros.Application.AuthenticationContext.Command
{
    public class AuthenticationCommand : IRequest<string?>
    {
        public AuthenticationCommand(AuthenticationRequestDto authenticationRequestDto)
        {
            AuthenticationRequestDto = authenticationRequestDto;
        }

        public AuthenticationRequestDto AuthenticationRequestDto { get; }
    }
}
