using D = DotAir.Domain.Entities;

namespace DotAir.API.DTO.Airport
{
    public class AirportDTO
    {
        public AirportDTO(D.Airport a)
        {
            Id = a.Id;
            City = a.City;
            Country = a.Country;
            Code = a.Code;
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Code { get; set; }
    }
}
