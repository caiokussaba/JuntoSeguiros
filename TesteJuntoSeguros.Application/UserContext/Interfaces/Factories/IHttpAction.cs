using TesteJuntoSeguros.Application.UserContext.Command;
using TesteJuntoSeguros.Domain.UserContext.Dtos;

namespace TesteJuntoSeguros.Application.UserContext.Interfaces.Factories
{
    public interface IHttpAction
    {
        string GetHttpAction();

        Task<UserDto?> SendAction(UserCommand? userCommand);
    }
}
