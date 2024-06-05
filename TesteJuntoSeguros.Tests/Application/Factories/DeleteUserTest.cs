using Moq;
using TesteJuntoSeguros.Application.UserContext.Command;
using TesteJuntoSeguros.Application.UserContext.Factories.ConcreteCreatorHttpAction;
using TesteJuntoSeguros.Domain.UserContext.Dtos;
using TesteJuntoSeguros.Domain.UserContext.Entities;
using TesteJuntoSeguros.Domain.UserContext.Interfaces;

namespace TesteJuntoSeguros.Tests.Application.Factories
{
    public class DeleteUserTest
    {
        private Mock<IUserRepository> _mockUserRepository;
        private DeleteUser _deleteUser;

        [SetUp]
        public void SetUp()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _deleteUser = new DeleteUser(_mockUserRepository.Object);
        }

        [Test]
        public void GetHttpAction_ShouldReturnDelete()
        {
            var result = _deleteUser.GetHttpAction();

            Assert.AreEqual("Delete", result);
        }

        [Test]
        public async Task SendAction_ShouldDeleteUserAndReturnUserDto()
        {
            var userDto = new UserDto
            {
                Id = "9ace67f4-1120-41d0-bb37-926e50384ed9"
            };
            var userCommand = new UserCommand(userDto);

            var user = new User
            {
                Id = userDto.Id
            };

            _mockUserRepository.Setup(repo => repo.Delete(It.IsAny<User>()))
                .ReturnsAsync(new UserDto { Id = "9ace67f4-1120-41d0-bb37-926e50384ed9" });

            // Act
            var result = await _deleteUser.SendAction(userCommand);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userDto.Id, result.Id);
            _mockUserRepository.Verify(repo => repo.Delete(It.Is<User>(u => u.Id == user.Id)), Times.Once);
        }
    }
}
