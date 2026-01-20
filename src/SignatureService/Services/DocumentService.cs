using SignatureService.Services.Crypto;

namespace SignatureService.Services;

public class DocumentService : IDocumentService
{
    private readonly IRsaSignatureService _rsa;

    public DocumentService(IRsaSignatureService rsa)
    {
        _rsa = rsa;
    }

    public string SignDocument(string content)
        => _rsa.Sign(content);

    public bool VerifyDocument(string content, string signature)
        => _rsa.Verify(content, signature);
}
