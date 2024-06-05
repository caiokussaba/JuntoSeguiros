﻿using TesteJuntoSeguros.Application.UserContext.Command;
using TesteJuntoSeguros.Application.UserContext.Interfaces.Factories;
using TesteJuntoSeguros.Application.UserContext.Util;
using TesteJuntoSeguros.Domain.UserContext.Dtos;
using TesteJuntoSeguros.Domain.UserContext.Entities;
using TesteJuntoSeguros.Domain.UserContext.Interfaces;

namespace TesteJuntoSeguros.Application.UserContext.Factories.ConcreteCreatorHttpAction
{
    public class CreateUser : IHttpAction
    {
        private readonly IUserRepository _userRepository;

        public CreateUser(IUserRepository userRepository) => _userRepository = userRepository;

        public string GetHttpAction()
        {
            return "Create";
        }

        public Task<UserDto?> SendAction(UserCommand? userCommand)
        {
            User user = new User
            {
                Id = userCommand?.UserDto?.Id,
                Login = userCommand?.UserDto?.Login,
                Password = Utils.Encrypt(userCommand?.UserDto?.Password)
            };

            return _userRepository.Create(user);
        }
    }
}
