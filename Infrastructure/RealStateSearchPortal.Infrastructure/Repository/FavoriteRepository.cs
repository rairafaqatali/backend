using Microsoft.EntityFrameworkCore;
using RealStateSearchPortal.Domain.Entities;
using RealStateSearchPortal.Domain.Interfaces;

namespace RealStateSearchPortal.Infrastructure.Repository
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly RealStateSearchPortalDbContext _db;

        public FavoriteRepository(RealStateSearchPortalDbContext db)
        {
            _db = db;
        }

        public async Task ToggleAsync(string userId, int propertyId)
        {
            var favorite = await _db.Favorites
                .FirstOrDefaultAsync(f => f.UserId == userId && f.PropertyId == propertyId);

            if (favorite != null)
            {
                _db.Favorites.Remove(favorite);
            }
            else
            {
                await _db.Favorites.AddAsync(new Favorite
                {
                    UserId = userId,
                    PropertyId = propertyId
                });
            }

            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Property>> GetAsync(string userId)
        {
            return await _db.Favorites
                .Where(f => f.UserId == userId)
                .Include(f => f.Property)
                .Select(f => f.Property)
                .ToListAsync();
        }
    }


}
