using System.Security.Cryptography;
using System.Text;

namespace TesteJuntoSeguros.Application.UserContext.Util
{
    public class Utils
    {
        public static string Encrypt(string? password)
        {
            HashAlgorithm algorithm = new MD5CryptoServiceProvider();

            Byte[] inputBytes = Encoding.UTF8.GetBytes(password);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }

        public static bool ValidatePassword(string? inputPassword, string? storedPassword)
        {
            return string.Equals(inputPassword, storedPassword);
        }
    }
}
