using D = DotAir.Domain.Entities;
namespace DotAir.API.DTO.Airport
{
    public class CustomerDTO
    {
        public CustomerDTO(D.Customer customer)
        {
            Id = customer.Id;
            LastName = customer.LastName;
            FirstName = customer.FirstName;
            Email = customer.Email;
            if(customer.Bookings != null)
            {
                NbBookings = customer.Bookings.Count;
            }
        }

        public int Id { get; init; }
        public string LastName { get; init; }
        public string FirstName { get; init; }
        public string Email { get; init; }
        public int? NbBookings { get; private set; }
    }
}
