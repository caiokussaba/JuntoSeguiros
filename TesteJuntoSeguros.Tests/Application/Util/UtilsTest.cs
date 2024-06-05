using System.Text;
using TesteJuntoSeguros.Application.UserContext.Util;

namespace TesteJuntoSeguros.Tests.Application.Util
{
    public class UtilsTest
    {
        [Test]
        public void ValidatePassword_ShouldReturnTrue_WhenPasswordsAreEqual()
        {
            const string inputPassword = "testPassword";
            const string storedPassword = "testPassword";

            var result = Utils.ValidatePassword(inputPassword, storedPassword);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidatePassword_ShouldReturnFalse_WhenPasswordsAreDifferent()
        {
            const string inputPassword = "testPassword";
            const string storedPassword = "differentPassword";

            var result = Utils.ValidatePassword(inputPassword, storedPassword);

            Assert.IsFalse(result);
        }
    }
}
