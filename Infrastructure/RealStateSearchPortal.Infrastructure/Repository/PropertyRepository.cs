using Microsoft.EntityFrameworkCore;
using RealStateSearchPortal.Domain.Entities;
using RealStateSearchPortal.Domain.Interfaces;
namespace RealStateSearchPortal.Infrastructure.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly RealStateSearchPortalDbContext _ctx;
        public PropertyRepository(RealStateSearchPortalDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Property>> GetAsync(
            string? city, int? bedrooms, decimal? minPrice, decimal? maxPrice)
        
        {
            var q = _ctx.Properties.AsQueryable();
            if (!string.IsNullOrEmpty(city)) q = q.Where(x => x.Title.Trim().ToLower().Contains(city.Trim().ToLower()));
            if (bedrooms.HasValue) q = q.Where(x => x.Bedrooms == bedrooms);
            if (minPrice.HasValue) q = q.Where(x => x.Price >= minPrice);
            if (maxPrice.HasValue) q = q.Where(x => x.Price <= maxPrice);
            return await q.ToListAsync();
        }

        public async Task<Property?> GetByIdAsync(int id) => await _ctx.Properties.FindAsync(id);
    }

}
