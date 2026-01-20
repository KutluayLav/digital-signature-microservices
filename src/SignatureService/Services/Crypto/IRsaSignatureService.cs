namespace SignatureService.Services.Crypto;

public interface IRsaSignatureService
{
    string Sign(string content);
    bool Verify(string content, string signature);
}
