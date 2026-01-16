using System.Security.Cryptography;
using System.Text;

namespace SignatureService.Security;

public class HashService : IHashService
{
    public string ComputeHash(string input)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToBase64String(bytes);
    }
}
