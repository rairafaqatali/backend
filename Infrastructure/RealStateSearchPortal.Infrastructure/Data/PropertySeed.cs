using Microsoft.EntityFrameworkCore;
using RealStateSearchPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStateSearchPortal.Infrastructure.Data
{
    public class PropertySeed
    {
        public static void Seed(ModelBuilder mb)
        {
            var random = new Random();
            var cities = new[] { "Sydney", "Melbourne", "Brisbane", "Perth", "Adelaide" };
            var titles = new[] { "Luxury Villa", "City Apartment", "Modern House", "Cozy Cottage", "Beachfront Condo" };
            var listingTypes = new[] { "Sale", "Rent" };

            var properties = new List<Property>();

            for (int i = 1; i <= 100; i++)
            {
                var city = cities[random.Next(cities.Length)];
                var title = titles[random.Next(titles.Length)] + " " + i;
                var price = random.Next(200000, 2000000);
                var bedrooms = random.Next(1, 6);
                var bathrooms = random.Next(1, 4);
                var carSpots = random.Next(0, 3);
                var listingType = listingTypes[random.Next(listingTypes.Length)];
                var description = $"{title} located in {city}";
                var imageUrl = $"https://picsum.photos/seed/{i}/300/200";

                properties.Add(new Property
                {
                    Id = i,
                    Title = title,
                    Address = city,
                    Price = price,
                    ListingType = listingType,
                    Bedrooms = bedrooms,
                    Bathrooms = bathrooms,
                    CarSpots = carSpots,
                    Description = description,
                    ImageUrls = imageUrl
                });
            }

            mb.Entity<Property>().HasData(properties);
        }
    }
}
