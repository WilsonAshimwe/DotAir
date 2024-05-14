using D = DotAir.Domain.Entities;

namespace DotAir.API.DTO.Booking
{
    public class BookingDTO
    {
        public BookingDTO(D.Booking b)
        {
            Id = b.Id;
            DepartureFlightId = b.DepartureFlightId;
            ReturnFlightId = b.ReturnFlightId;
            CustomerId = b.CustomerId;
            Price = b.Price;
            Reference = b.Reference;
            CancelInsurance = b.CancelInsurance;
            ExtraLuggageNb = b.ExtraLuggageNb;
        }

        public int Id { get; set; }
        public int DepartureFlightId { get; set; }
        public int? ReturnFlightId { get; set; }
        public int CustomerId { get; set; }
        public int Price { get; set; } // en cents
        public string Reference { get; set; } = null!;
        public bool CancelInsurance { get; set; }
        public int ExtraLuggageNb { get; set; }
    }
}
