using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RealStateSearchPortal.Domain.Interfaces;
using RealStateSearchPortal.Infrastructure.Data;
using RealStateSearchPortal.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStateSearchPortal.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<RealStateSearchPortalDbContext>(options =>
                options.UseSqlServer("name=ConnectionStrings:RealStateSearchPortalDbConnection",
                x => x.MigrationsAssembly("RealStateSearchPortal.Infrastructure")));

            services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
        }

        public static async Task MigrateDatabase(this IServiceProvider serviceProvider)
        {
            var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<RealStateSearchPortalDbContext>>();

            using (var dbContext = new RealStateSearchPortalDbContext(dbContextOptions))
            {
                dbContext.Database.Migrate();
                await SeedRoles.SeedRolesAsync(serviceProvider);
            }
        }
    }
}
