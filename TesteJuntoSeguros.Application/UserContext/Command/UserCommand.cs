using TesteJuntoSeguros.Domain.UserContext.Dtos;
using MediatR;

namespace TesteJuntoSeguros.Application.UserContext.Command
{
    public class UserCommand : IRequest<UserDto?>
    {
        public UserCommand(UserDto? userDto)
        {
            UserDto = userDto;
        }

        public UserDto? UserDto { get; }
    }
}
