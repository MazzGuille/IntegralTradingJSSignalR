using System.Security.Cryptography;
using System.Text;

namespace IntegralTradingJS.Helpers
{
    public class Encrypt
    {
        public string ConvertirSHA256(string text)
        {
            if (text == null)
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(text));
                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
