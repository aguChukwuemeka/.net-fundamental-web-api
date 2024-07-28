using CityInfo.API;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Api.Controllers
{
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

        [HttpGet("{pointsOfInterestId}", Name = "GetPointOfInterest")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest(int cityId, int pointsOfInterestId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            var pointOfInterest = city?.PointOfInterest.FirstOrDefault(c => c.Id == pointsOfInterestId);
            if (city == null || pointOfInterest == null)
            {
                return NotFound();
            }
            return Ok(pointOfInterest);
        }

        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId, PointOfInterestForCreationDto pointOfInterest)
        {
            if(!ModelState.IsValid) return BadRequest();
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointOfInterest).Max(p => p.Id);
            Console.WriteLine(maxPointOfInterestId);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = maxPointOfInterestId + 1,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description,
                Prefecture = city.Prefecture
            };
            city.PointOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest", new { cityId = cityId, pointsOfInterestId = finalPointOfInterest.Id }, finalPointOfInterest);
        }

        [HttpPut("{pointsOfInterestId}")]
        public ActionResult UpdatePointOfInterest(int cityId, int pointsOfInterestId, PointOfInterestForUpdateDto pointOfInterest)
        { 
            if (!ModelState.IsValid) return BadRequest();
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            var pointOfInterestToUpdate = city?.PointOfInterest.FirstOrDefault(p => p.Id == pointsOfInterestId);
            if (city == null || pointOfInterestToUpdate == null)
            {
                return NotFound();
            }
            pointOfInterestToUpdate.Name = pointOfInterest.Name;
            pointOfInterestToUpdate.Description = pointOfInterest.Description;

            return NoContent();
        }
    }
}
