using CityInfo.API;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Api.Controllers{
    [ApiController]
    [Route("api/cities/{cityId}/pointsofinterest")]
    public class PointOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city.NumberOfPointsOfInterest);
        }
        [HttpGet("{pointsOfInterestId}")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest(int cityId, int pointsOfInterestId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            var pointOfInterest = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == pointsOfInterestId);
            if (city == null  || pointOfInterest == null)
            {
                return NotFound();
            }
            return Ok(pointOfInterest);
        }
    }
}