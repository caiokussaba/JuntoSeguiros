using TesteJuntoSeguros.Application.UserContext.Command;
using TesteJuntoSeguros.Application.UserContext.Interfaces.Factories;
using TesteJuntoSeguros.Domain.UserContext.Dtos;
using TesteJuntoSeguros.Domain.UserContext.Entities;
using TesteJuntoSeguros.Domain.UserContext.Interfaces;

namespace TesteJuntoSeguros.Application.UserContext.Factories.ConcreteCreatorHttpAction
{
    public class DeleteUser : IHttpAction
    {
        private readonly IUserRepository _userRepository;

        public DeleteUser(IUserRepository userRepository) => _userRepository = userRepository;

        public string GetHttpAction()
        {
            return "Delete";
        }

        public Task<UserDto?> SendAction(UserCommand? userCommand)
        {
            User user = new User
            {
                Id = userCommand?.UserDto?.Id
            };

            return _userRepository.Delete(user);
        }
    }
}
