using System.ComponentModel.DataAnnotations.Schema;

namespace DotAir.Domain.Entities
{
    [Table("Bookings")]
    public class Booking
    {
        public int Id { get; set; }
        public int DepartureFlightId { get; set; }
        public int? ReturnFlightId { get; set; }
        public int CustomerId { get; set; }
        public int Price { get; set; } // en cents
        public string Reference { get; set; } = null!;
        public bool CancelInsurance { get; set; }
        public int ExtraLuggageNb { get; set; }
        public Customer Customer { get; set; } = null!;
        public Flight DepartureFlight { get; set; } = null!;
        public Flight? ReturnFlight { get; set; }
    }
}
