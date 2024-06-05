using Moq;
using TesteJuntoSeguros.Application.UserContext.Command;
using TesteJuntoSeguros.Application.UserContext.Factories.ConcreteCreatorHttpAction;
using TesteJuntoSeguros.Application.UserContext.Util;
using TesteJuntoSeguros.Domain.UserContext.Dtos;
using TesteJuntoSeguros.Domain.UserContext.Entities;
using TesteJuntoSeguros.Domain.UserContext.Interfaces;

namespace TesteJuntoSeguros.Tests.Application.Factories
{
    public class CreateUserTest
    {
        private Mock<IUserRepository> _mockUserRepository;
        private CreateUser _createUser;

        [SetUp]
        public void SetUp()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _createUser = new CreateUser(_mockUserRepository.Object);
        }

        [Test]
        public void GetHttpAction_ShouldReturnCreate()
        {
            var result = _createUser.GetHttpAction();

            Assert.AreEqual("Create", result);
        }

        [Test]
        public async Task SendAction_ShouldCreateUserAndReturnUserDto()
        {
            // Arrange
            var userDto = new UserDto
            {
                Id = "9ace67f4-1120-41d0-bb37-926e50384ed9",
                Login = "testLogin",
                Password = "testPassword"
            };
            var userCommand = new UserCommand(userDto);

            var user = new User
            {
                Id = userDto.Id,
                Login = userDto.Login,
                Password = Utils.Encrypt(userDto.Password)
            };

            _mockUserRepository.Setup(repo => repo.Create(It.IsAny<User>()))
                .ReturnsAsync(new UserDto { Id = "9ace67f4-1120-41d0-bb37-926e50384ed9", Login = "testLogin" });

            var result = await _createUser.SendAction(userCommand);


            Assert.IsNotNull(result);
            Assert.AreEqual(userDto.Id, result.Id);
            Assert.AreEqual(userDto.Login, result.Login);
            _mockUserRepository.Verify(repo => repo.Create(It.Is<User>(u =>
                u.Id == user.Id &&
                u.Login == user.Login &&
                u.Password == user.Password)), Times.Once);
        }
    }
}
