using RealStateSearchPortal.Application.DTOs;
using RealStateSearchPortal.Application.Interfaces;
using RealStateSearchPortal.Domain.Entities;
using RealStateSearchPortal.Domain.Interfaces;

namespace RealStateSearchPortal.Application.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _repo;

        public FavoriteService(IFavoriteRepository repo)
        {
            _repo = repo;
        }

        public async Task ToggleAsync(string userId, int propertyId) => await _repo.ToggleAsync(userId, propertyId);

        public async Task<IEnumerable<Property>> GetAsync(string userId) => await _repo.GetAsync(userId);
    }


}
