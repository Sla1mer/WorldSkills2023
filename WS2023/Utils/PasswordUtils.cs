using System.Security.Cryptography;
using System.Text;

namespace WS2023.Utils
{
    public class PasswordUtils
    {

        public static string passwordToMd5(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            return Convert.ToBase64String(hash);
        }
    }
}
