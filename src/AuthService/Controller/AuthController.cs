using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AuthService.Models;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // Public endpoint (no token needed)
        [HttpGet("public")]
        [AllowAnonymous]
        public IActionResult PublicEndpoint()
        {
            return Ok("This is a public endpoint, no authentication required.");
        }

        // Protected endpoint (requires any valid token) 
        [HttpGet("protected")]
        [Authorize]
        public IActionResult ProtectedEndpoint()
        {
            var username = User.Identity?.Name ?? "unknown";
            return Ok($"Hello {username}, you have accessed a protected endpoint.");
        }

        // Role-based endpoint (requires ROLE_ADMIN)
        [HttpGet("admin")]
        [Authorize(Roles = "ROLE_ADMIN")]
        public IActionResult AdminEndpoint()
        {
            var user = new UserModel
            {
                Username = User.Identity?.Name,
                Email = User.FindFirst(ClaimTypes.Email)?.Value,
                Roles = User.FindAll(ClaimTypes.Role).Select(r => r.Value)
            };

            return Ok(new
            {
                Message = "Welcome, Admin!",
                User = user
            });
        }
    }
}
