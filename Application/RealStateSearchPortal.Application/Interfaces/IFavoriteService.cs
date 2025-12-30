using RealStateSearchPortal.Application.DTOs;
using RealStateSearchPortal.Domain.Entities;

namespace RealStateSearchPortal.Application.Interfaces
{
    public interface IFavoriteService
    {
        Task ToggleAsync(string userId, int propertyId);
        Task<IEnumerable<Property>> GetAsync(string userId);
    }
}
