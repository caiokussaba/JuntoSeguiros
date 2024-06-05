using Moq;
using TesteJuntoSeguros.Application.UserContext.Command;
using TesteJuntoSeguros.Application.UserContext.Handler;
using TesteJuntoSeguros.Application.UserContext.Interfaces.Factories;
using TesteJuntoSeguros.Domain.UserContext.Dtos;

namespace TesteJuntoSeguros.Tests.Application.Handler
{
    public class UserHandlerTest
    {
        private Mock<IHttpActionFactory> _mockHttpActionFactory;
        private Mock<IHttpAction> _mockHttpAction;
        private UserHandler _userHandler;

        [SetUp]
        public void SetUp()
        {
            _mockHttpActionFactory = new Mock<IHttpActionFactory>();
            _mockHttpAction = new Mock<IHttpAction>();

            _userHandler = new UserHandler(_mockHttpActionFactory.Object);
        }

        [Test]
        public async Task Handle_ShouldCallCorrectHttpAction_WithUserCommand()
        {
            var userDto = new UserDto
            {
                HttpAction = "Create"
            };
            var userCommand = new UserCommand(userDto);

            _mockHttpActionFactory.Setup(factory => factory.GetHttpAction("Create")).Returns(_mockHttpAction.Object);
            _mockHttpAction.Setup(action => action.SendAction(userCommand)).ReturnsAsync(new UserDto());

            var result = await _userHandler.Handle(userCommand, CancellationToken.None);

            Assert.IsNotNull(result);
            _mockHttpAction.Verify(action => action.SendAction(userCommand), Times.Once);
        }
    }
}
