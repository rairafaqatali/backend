using RealStateSearchPortal.Domain.Entities;

namespace RealStateSearchPortal.Domain.Interfaces
{
    public interface IFavoriteRepository
    {
        Task ToggleAsync(string userId, int propertyId);
        Task<IEnumerable<Property>> GetAsync(string userId);
    }

}
