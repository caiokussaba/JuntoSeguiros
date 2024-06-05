using Moq;
using TesteJuntoSeguros.Application.UserContext.Factories.Creator;
using TesteJuntoSeguros.Application.UserContext.Interfaces.Factories;

namespace TesteJuntoSeguros.Tests.Application.Factories
{
    public class HttpActionFactoryTest
    {
        private Mock<IHttpAction> _mockHttpAction1;
        private Mock<IHttpAction> _mockHttpAction2;
        private IEnumerable<IHttpAction> _httpActions;
        private HttpActionFactory _httpActionFactory;

        [SetUp]
        public void SetUp()
        {
            _mockHttpAction1 = new Mock<IHttpAction>();
            _mockHttpAction1.Setup(x => x.GetHttpAction()).Returns("Action1");

            _mockHttpAction2 = new Mock<IHttpAction>();
            _mockHttpAction2.Setup(x => x.GetHttpAction()).Returns("Action2");

            _httpActions = new List<IHttpAction> { _mockHttpAction1.Object, _mockHttpAction2.Object };

            _httpActionFactory = new HttpActionFactory(_httpActions);
        }

        [Test]
        public void GetHttpAction_ShouldReturnNull_WhenActionDoesNotExist()
        {
            var actionName = "NonExistentAction";

            var result = _httpActionFactory.GetHttpAction(actionName);

            Assert.IsNull(result);
        }
    }
}
