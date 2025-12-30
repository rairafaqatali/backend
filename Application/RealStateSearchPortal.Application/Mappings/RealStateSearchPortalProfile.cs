using AutoMapper;
using RealStateSearchPortal.Application.DTOs;
using RealStateSearchPortal.Domain.Entities;

namespace RealStateSearchPortal.Application.Mappings
{
    public class RealStateSearchPortalProfile : Profile
    {
        public RealStateSearchPortalProfile()
        {
            CreateMap<Property, PropertyResponseDto>().ReverseMap();
        }
    }
}
