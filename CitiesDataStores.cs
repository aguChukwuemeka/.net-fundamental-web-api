using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto>  Cities { get; set; }
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "New York",
                    Description = "The most populous city in the United States",
                    Prefecture = "The Big Apple",
                    PointOfInterest = {
                        new PointOfInterestDto() { Id = 1, Name = "Empire State Building", Description = "An iconic landmark in New York City", Prefecture = "The Big Apple" },
                        new PointOfInterestDto() { Id = 2, Name = "Central Park", Description = "A popular tourist destination", Prefecture = "The Big Apple" }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "London",
                    Description = "The capital and most populous city of England and the United Kingdom",
                    Prefecture = "The City of Westminster",
                    PointOfInterest = {
                        new PointOfInterestDto() { Id = 3, Name = "Big Ben", Description = "A symbol of Westminster Abbey", Prefecture = "The City of Westminster" },
                        new PointOfInterestDto() { Id = 4, Name = "Shibuya", Description = "A popular tourist destination", Prefecture = "Shibuya" }
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Tokyo",
                    Description = "The capital and most populous city of Japan",
                    Prefecture = "Shibuya",
                    PointOfInterest = {
                        new PointOfInterestDto() { Id = 5, Name = "Shibuya Crossing", Description = "A popular tourist destination", Prefecture = "Shibuya" },
                        new PointOfInterestDto() { Id = 6, Name = "Gion", Description = "A popular tourist destination", Prefecture = "Shibuya" }
                    }
                }
            };
        }
    }
}