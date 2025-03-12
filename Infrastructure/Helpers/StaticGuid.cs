using System.Security.Cryptography;
using System.Text;

namespace Flag_Explorer_App.Infrastructure.Helpers
{
    public static class StaticGuid
    {
        public static Guid GenerateDeterministicGuid(string input)
        {
            using var sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            Array.Resize(ref hash, 16);
            return new Guid(hash);
        }
    }
}
