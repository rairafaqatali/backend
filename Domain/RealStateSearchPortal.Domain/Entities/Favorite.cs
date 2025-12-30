namespace RealStateSearchPortal.Domain.Entities
{
    public class Favorite
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public int PropertyId { get; set; }
        public Property Property { get; set; } = null!;
    }
}
