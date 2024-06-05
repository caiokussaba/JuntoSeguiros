using TesteJuntoSeguros.Application.UserContext.Command;
using TesteJuntoSeguros.Application.UserContext.Interfaces.Factories;
using TesteJuntoSeguros.Application.UserContext.Util;
using TesteJuntoSeguros.Domain.UserContext.Dtos;
using TesteJuntoSeguros.Domain.UserContext.Entities;
using TesteJuntoSeguros.Domain.UserContext.Interfaces;

namespace TesteJuntoSeguros.Application.UserContext.Factories.ConcreteCreatorHttpAction
{
    public class GetUser : IHttpAction
    {
        private readonly IUserRepository _userRepository;

        public GetUser(IUserRepository userRepository) => _userRepository = userRepository;

        public string GetHttpAction()
        {
            return "Get";
        }

        public async Task<UserDto?> SendAction(UserCommand userCommand)
        {
            User user = new User
            {
                Id = userCommand?.UserDto?.Id
            };

            return await _userRepository.GetById(user);
        }
    }
}
