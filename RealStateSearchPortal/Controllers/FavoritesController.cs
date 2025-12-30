using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealStateSearchPortal.Application.Interfaces;
using System.Security.Claims;

namespace RealStateSearchPortal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles ="BUYER")]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _service;
        public FavoritesController(IFavoriteService service) => _service = service;

        [HttpPost("{propertyId}")]
        public async Task<IActionResult> Toggle(int propertyId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await _service.ToggleAsync(userId, propertyId);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetUserFavorites()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var resposne = await _service.GetAsync(userId);
            return Ok(resposne);
        }
    }
}
