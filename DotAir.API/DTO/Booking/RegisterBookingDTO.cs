using System.ComponentModel.DataAnnotations;

namespace DotAir.API.DTO.Booking
{
    public class RegisterBookingDTO
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int FlightId { get; set; }
        // assurance ? extra luggage ? vol retour ?
    }
}
