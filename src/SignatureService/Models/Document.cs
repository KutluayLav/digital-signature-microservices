namespace SignatureService.Models;

public class Document
{
    public Guid Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string Hash { get; set; } = string.Empty;
    public string UploadedBy { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
