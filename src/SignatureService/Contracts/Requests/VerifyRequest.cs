namespace SignatureService.Contracts.Requests;

public class VerifyRequest
{
    public string Content { get; set; } = string.Empty;
    public string Signature { get; set; } = string.Empty;
}
