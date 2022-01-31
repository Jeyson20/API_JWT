using System.Security.Cryptography;
using System.Text;

namespace API_JWT.Models.Tools
{
    public class Encrypt
    {
        public static string Encryption(string password)
        {
            SHA256 sha = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] strem = null;
            StringBuilder StringB = new StringBuilder();

            strem = sha.ComputeHash(encoding.GetBytes(password));
            for (int i = 0; i < strem.Length; i++) StringB.AppendFormat("{0:x2}", strem[i]);

            return StringB.ToString();

        }
    }
}
