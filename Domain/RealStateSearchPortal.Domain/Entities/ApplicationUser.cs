using Microsoft.AspNetCore.Identity;

namespace RealStateSearchPortal.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    }
}

