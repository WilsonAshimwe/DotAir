using System.ComponentModel.DataAnnotations.Schema;

namespace DotAir.Domain.Entities
{
    [Table("Airports")]
    public class Airport
    {
        public int Id { get; set; }
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Code { get; set; } = null!;
        [InverseProperty("DepartureAirport")]
        public List<Flight> DepartFlights { get; set; } = null!;
        [InverseProperty("ArrivalAirport")]
        public List<Flight> ArrivalFlights { get; set; } = null!;
    }
}
