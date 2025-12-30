using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealStateSearchPortal.Domain.Entities;
using RealStateSearchPortal.Infrastructure.Data;

public class RealStateSearchPortalDbContext : IdentityDbContext<ApplicationUser>
{
    public virtual DbSet<Property> Properties { get; set; }
    public virtual DbSet<Favorite> Favorites { get; set; }

    public RealStateSearchPortalDbContext(DbContextOptions<RealStateSearchPortalDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb); // important!

        mb.Entity<Favorite>().HasKey(x => new { x.UserId, x.PropertyId });

        PropertySeed.Seed(mb);
    }
}
