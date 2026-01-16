using Microsoft.AspNetCore.Mvc;
using SignatureService.Contracts;
using SignatureService.Services;

namespace SignatureService.Controllers;

[ApiController]
[Route("api/signature")]
public class SignatureController : ControllerBase
{
    private readonly IDocumentService _documentService;

    public SignatureController(IDocumentService documentService)
    {
        _documentService = documentService;
    }

    [HttpPost("sign")]
    public IActionResult Sign([FromBody] SignRequest request)
    {
        var hash = _documentService.SignDocument(request.Content);
        return Ok(new { hash });
    }
}
