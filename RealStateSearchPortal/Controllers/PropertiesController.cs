using Microsoft.AspNetCore.Mvc;
using RealStateSearchPortal.Application.Interfaces;

namespace RealStateSearchPortal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _service;
        public PropertiesController(IPropertyService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Search(string? city, int? bedrooms, decimal? minPrice, decimal? maxPrice)
        {
            return Ok(await _service.SearchAsync(city, bedrooms, minPrice, maxPrice));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyById(int id)
        {
            return Ok(await _service.GetAsync(id));
        }
    }
}
