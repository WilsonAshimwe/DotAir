using System.ComponentModel.DataAnnotations.Schema;

namespace DotAir.Domain.Entities
{
    [Table("Customers")]
    public class Customer: Login
    {
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public List<Booking> Bookings { get; set; } = null!;
        public override string Role { get => "CUSTOMER"; }
    }
}
