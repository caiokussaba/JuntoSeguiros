using TesteJuntoSeguros.Domain.UserContext.Entities;

namespace TesteJuntoSeguros.Tests.Domain.UserContext
{
    public class UserTest
    {
        [Test]
        public void User_DefaultConstructor_ShouldInitializePropertiesToDefaultValues()
        {
            var user = new User();

            Assert.IsNull(user.Login, "Login should be null by default.");
            Assert.IsNull(user.Password, "Password should be null by default.");
            Assert.IsNotNull(user.LastUpdate, "LastUpdate should be initialized to current date/time.");
            Assert.IsNotNull(user.CreateDate, "CreateDate should be initialized to current date/time.");
        }

        [Test]
        public void User_SetLogin_ShouldStoreLogin()
        {
            var user = new User();
            var expectedLogin = "testUser";

            user.Login = expectedLogin;
            Assert.AreEqual(expectedLogin, user.Login, "Login should store the value assigned.");
        }

        [Test]
        public void User_SetPassword_ShouldStorePassword()
        {
            var user = new User();
            var expectedPassword = "testPassword";

            user.Password = expectedPassword;
            Assert.AreEqual(expectedPassword, user.Password, "Password should store the value assigned.");
        }

        [Test]
        public void User_LastUpdate_ShouldBeCurrentDateTimeByDefault()
        {
            var user = new User();

            var now = DateTime.Now;
            Assert.That(user.LastUpdate, Is.EqualTo(now).Within(1).Seconds, "LastUpdate should be set to current date/time by default.");
        }

        [Test]
        public void User_CreateDate_ShouldBeCurrentDateTimeByDefault()
        {
            var user = new User();

            var now = DateTime.Now;
            Assert.That(user.CreateDate, Is.EqualTo(now).Within(1).Seconds, "CreateDate should be set to current date/time by default.");
        }
    }
}
