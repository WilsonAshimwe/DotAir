using System.ComponentModel.DataAnnotations.Schema;

namespace DotAir.Domain.Entities
{
    [Table("Planes")]
    public class Plane
    {
        public int Id { get; set; }
        public string Ref { get; set; } = null!;
        public int SeatsNb { get; set; }
        public int LegsSpace { get; set; }
        public bool IsAvailable { get; set; }
        public string PlaneType { get; set; } = null!;
        public List<Flight> Flights { get; set; } = null!;
    }
}
