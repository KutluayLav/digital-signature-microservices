using SignatureService.Security;

namespace SignatureService.Services;

public class DocumentService : IDocumentService
{
    private readonly IHashService _hashService;

    public DocumentService(IHashService hashService)
    {
        _hashService = hashService;
    }

    public string SignDocument(string content)
    {
        return _hashService.ComputeHash(content);
    }
}
