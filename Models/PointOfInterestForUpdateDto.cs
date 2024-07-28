using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Models{
    public class PointOfInterestForUpdateDto
    {
        [Required(ErrorMessage = "You should provide a required parameter")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Description { get; set; }

    }
}