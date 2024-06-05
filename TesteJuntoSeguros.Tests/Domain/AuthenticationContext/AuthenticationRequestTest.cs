using TesteJuntoSeguros.Domain.AuthenticationContext.Request;

namespace TesteJuntoSeguros.Tests.Domain.AuthenticationContext
{
    public class AuthenticationRequestTest
    {
        [Test]
        public void AuthenticationRequest_DefaultConstructor_ShouldInitializePropertiesToNull()
        {
            var authRequest = new AuthenticationRequest();

            Assert.IsNull(authRequest.Login, "Login should be null by default.");
            Assert.IsNull(authRequest.Password, "Password should be null by default.");
        }

        [Test]
        public void AuthenticationRequest_SetLogin_ShouldStoreLogin()
        {
            var authRequest = new AuthenticationRequest();
            var expectedLogin = "testUser";

            authRequest.Login = expectedLogin;
            Assert.AreEqual(expectedLogin, authRequest.Login, "Login should store the value assigned.");
        }

        [Test]
        public void AuthenticationRequest_SetPassword_ShouldStorePassword()
        {
            var authRequest = new AuthenticationRequest();
            var expectedPassword = "testPassword";

            authRequest.Password = expectedPassword;
            Assert.AreEqual(expectedPassword, authRequest.Password, "Password should store the value assigned.");
        }
    }
}
