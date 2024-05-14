using DotAir.API.Validators;
using System.ComponentModel.DataAnnotations;

namespace DotAir.API.DTO.Customer
{
    public class RegisterDTO
    {
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string FirstName { get; set; } = null!;

        [Required]
        [AdultValidator]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Password { get; set; } = null!;
    }
}
