using RealStateSearchPortal.Application.DTOs;

namespace RealStateSearchPortal.Application.Interfaces
{
    public interface IPropertyService
    {
        Task<IEnumerable<PropertyResponseDto>> SearchAsync(
            string? city, int? bedrooms, decimal? minPrice, decimal? maxPrice);
        Task<PropertyResponseDto?> GetAsync(int id);
    }
}
