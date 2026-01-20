using System.Security.Cryptography;
using System.Text;

namespace SignatureService.Services.Crypto;

public class RsaSignatureService : IRsaSignatureService
{
    private const string KeyPath = "rsa-key.xml";
    private readonly RSA _rsa;

    public RsaSignatureService()
    {
        _rsa = RSA.Create();

        if (File.Exists(KeyPath))
        {
            var xml = File.ReadAllText(KeyPath);
            _rsa.FromXmlString(xml);
        }
        else
        {
            _rsa.KeySize = 2048;
            File.WriteAllText(KeyPath, _rsa.ToXmlString(true));
        }
    }

    public string Sign(string content)
    {
        var data = Encoding.UTF8.GetBytes(content);
        var signature = _rsa.SignData(
            data,
            HashAlgorithmName.SHA256,
            RSASignaturePadding.Pkcs1
        );

        return Convert.ToBase64String(signature);
    }

    public bool Verify(string content, string signature)
    {
        var data = Encoding.UTF8.GetBytes(content);
        var sig = Convert.FromBase64String(signature);

        return _rsa.VerifyData(
            data,
            sig,
            HashAlgorithmName.SHA256,
            RSASignaturePadding.Pkcs1
        );
    }
}
