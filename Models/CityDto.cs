namespace CityInfo.API.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Prefecture { get; set; }

        public int NumberOfPointsOfInterest
        {
            get => PointOfInterest.Count;
        }

        public List<PointOfInterestDto> PointOfInterest { get; set; } = new List<PointOfInterestDto>();
    }
}