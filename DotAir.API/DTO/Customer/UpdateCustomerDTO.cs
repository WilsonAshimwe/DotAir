using System.ComponentModel.DataAnnotations;

namespace DotAir.API.DTO.Customer
{
    public class UpdateCustomerDTO
    {
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string FirstName { get; set; } = null!;
        public string? Password { get; set; } = null!;
    }
}
