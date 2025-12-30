using AutoMapper;
using RealStateSearchPortal.Application.DTOs;
using RealStateSearchPortal.Application.Interfaces;
using RealStateSearchPortal.Domain.Interfaces;

namespace RealStateSearchPortal.Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _repo;
        private readonly IMapper _mapper;

        public PropertyService(IPropertyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PropertyResponseDto>> SearchAsync(
            string? city, int? bedrooms, decimal? minPrice, decimal? maxPrice)
            => _mapper.Map<IEnumerable<PropertyResponseDto>>(
                await _repo.GetAsync(city, bedrooms, minPrice, maxPrice));

        public async Task<PropertyResponseDto?> GetAsync(int id)
            => _mapper.Map<PropertyResponseDto?>(await _repo.GetByIdAsync(id));
    }

}
