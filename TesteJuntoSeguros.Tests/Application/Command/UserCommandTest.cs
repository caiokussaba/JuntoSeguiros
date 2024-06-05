using TesteJuntoSeguros.Application.UserContext.Command;
using TesteJuntoSeguros.Domain.UserContext.Dtos;

namespace TesteJuntoSeguros.Tests.Application.Command
{
    public class UserCommandTest
    {
        [Test]
        public void UserCommand_Constructor_ShouldInitializeUserDto()
        {
            var expectedUserDto = new UserDto { Id = "f7e1bc9b-315d-418a-bc0c-cbc03bbdbe08", Login = "teste", Password = "teste" };

            var userCommand = new UserCommand(expectedUserDto);
            Assert.AreEqual(expectedUserDto, userCommand.UserDto, "UserDto should be initialized with the value provided to the constructor.");
        }

        [Test]
        public void UserCommand_Constructor_ShouldHandleNullUserDto()
        {
            UserDto? expectedUserDto = null;
            var userCommand = new UserCommand(expectedUserDto);

            Assert.IsNull(userCommand.UserDto, "UserDto should be null when null is provided to the constructor.");
        }
    }
}
