using Microsoft.AspNetCore.Mvc;
using SignatureService.Services;
using SignatureService.Contracts.Requests;
using SignatureService.Contracts.Responses;

namespace SignatureService.Controllers;

[ApiController]
[Route("api/signature")]
[Produces("application/json")]
public class SignatureController : ControllerBase
{
    private readonly IDocumentService _service;

    public SignatureController(IDocumentService service)
    {
        _service = service;
    }

    [HttpPost("sign")]
    [ProducesResponseType(typeof(SignResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<SignResponse> Sign([FromBody] SignRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Content))
            return BadRequest("Content cannot be empty.");

        var signature = _service.SignDocument(request.Content);

        return Ok(new SignResponse
        {
            Signature = signature
        });
    }

    [HttpPost("verify")]
    [ProducesResponseType(typeof(VerifyResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<VerifyResponse> Verify([FromBody] VerifyRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Content) ||
            string.IsNullOrWhiteSpace(request.Signature))
            return BadRequest("Content and signature are required.");

        var isValid = _service.VerifyDocument(
            request.Content,
            request.Signature
        );

        return Ok(new VerifyResponse
        {
            IsValid = isValid
        });
    }
}
