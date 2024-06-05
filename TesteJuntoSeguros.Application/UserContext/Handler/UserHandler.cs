using TesteJuntoSeguros.Application.UserContext.Command;
using TesteJuntoSeguros.Application.UserContext.Interfaces.Factories;
using TesteJuntoSeguros.Domain.UserContext.Dtos;
using MediatR;

namespace TesteJuntoSeguros.Application.UserContext.Handler
{
    public class UserHandler : IRequestHandler<UserCommand, UserDto?>
    {
        private readonly IHttpActionFactory _httpActionFactory;
        public UserHandler(IHttpActionFactory httpActionFactory)
        {
            _httpActionFactory = httpActionFactory;
        }

        public async Task<UserDto?> Handle(UserCommand userCommand, CancellationToken cancellationToken)
        {
            var httpAction = _httpActionFactory.GetHttpAction(userCommand?.UserDto?.HttpAction);

            var response = await httpAction.SendAction(userCommand);

            return response;
        }
    }
}
