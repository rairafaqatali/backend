namespace RealStateSearchPortal.Domain.Entities
{
    public class Property
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Address { get; set; } = null!;
        public decimal Price { get; set; }
        public string ListingType { get; set; } = null!;
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int CarSpots { get; set; }
        public string Description { get; set; } = null!;
        public string ImageUrls { get; set; } = null!;
    }
}
