using RealStateSearchPortal.Domain.Entities;

namespace RealStateSearchPortal.Domain.Interfaces
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetAsync(
            string? city, int? bedrooms, decimal? minPrice, decimal? maxPrice);
        Task<Property?> GetByIdAsync(int id);
    }
}
