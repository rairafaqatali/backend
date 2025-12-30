namespace RealStateSearchPortal.Application.DTOs
{
    public class PropertyResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Address { get; set; } = null!;
        public decimal Price { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int CarSpots { get; set; }
        public string ListingType { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
