using System.Security.Cryptography;
using System.Text;

namespace SmollanWebAPI.Services.EncryptService
{
    public class EncryptService : IEncryptService
    {
        public string EncryptString(string text)
        {
            StringBuilder stringBuilder = new();

            byte[] bytes;

            using (SHA256 sha256 = SHA256.Create()) 
            {
                bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            }

            for(var i = 0; i < bytes.Length; i++)
            {
                stringBuilder.Append(bytes[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
