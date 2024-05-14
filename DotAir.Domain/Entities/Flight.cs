using DotAir.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotAir.Domain.Entities
{
    [Table("Flights")]
    public record Flight
    {
        public int Id { get; set; }
        public int PlaneId { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int BasePrice { get; set; } // cents
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }
        public Airport DepartureAirport { get; set; } = null!;
        public Airport ArrivalAirport { get; set; } = null!;

        [Column(TypeName = "VARCHAR(50)")]
        public FlightStatus Status { get; set; }
        public Plane Plane { get; set; } = null!;
        [InverseProperty("DepartureFlight")]
        public List<Booking> DepartureBookings { get; set; } = null!;
        [InverseProperty("ReturnFlight")]
        public List<Booking> ReturnBookings { get; set; } = null!;

        /// <summary>
        /// Pas dans la DB mais calculé en c#
        /// </summary>
        [NotMapped]
        public List<Booking> Bookings { get => DepartureBookings.Union(ReturnBookings).ToList(); }
    }
}
