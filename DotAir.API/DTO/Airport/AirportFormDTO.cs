using System.ComponentModel.DataAnnotations;

namespace DotAir.API.DTO.Airport
{
    public class AirportFormDTO
    {
        [Required]
        [MaxLength(255)]
        public string City { get; set; } = null!;

        [Required]
        [MaxLength(2)]
        [MinLength(2)]
        public string Country { get; set; } = null!;

        [Required]
        [RegularExpression("[A-Z]{3}")]
        public string Code { get; set; } = null!;
    }
}
