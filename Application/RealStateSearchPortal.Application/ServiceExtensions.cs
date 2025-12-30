using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RealStateSearchPortal.Application.Interfaces;
using RealStateSearchPortal.Application.Mappings;
using RealStateSearchPortal.Application.Services;
using RealStateSearchPortal.Domain.Interfaces;

namespace RealStateSearchPortal.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<IPropertyService, PropertyService>();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new RealStateSearchPortalProfile());
            }, new LoggerFactory());

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
