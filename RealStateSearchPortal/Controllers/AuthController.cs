using Microsoft.AspNetCore.Mvc;
using RealStateSearchPortal.Application.DTOs;
using RealStateSearchPortal.Application.Interfaces;

namespace RealStateSearchPortal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service) => _service = service;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            await _service.RegisterAsync(dto);
            return Created();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            return Ok(new { token = await _service.LoginAsync(dto) });
        }

    }
}
