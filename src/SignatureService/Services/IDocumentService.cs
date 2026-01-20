namespace SignatureService.Services;

public interface IDocumentService
{
    string SignDocument(string content);
    bool VerifyDocument(string content, string signature);
}
