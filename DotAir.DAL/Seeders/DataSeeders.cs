using DotAir.Domain.Entities;
using DotAir.Domain.Enums;

namespace DotAir.DAL.Seeders
{
    public static class DataSeeders
    {
        public static IEnumerable<Plane> InitPlanes()
        {
            yield return new Plane() { Id = 1, Ref = "1234", IsAvailable = true, SeatsNb = 42, LegsSpace = 79, PlaneType = "Boeing 747" };
        }

        public static IEnumerable<Flight> InitFlights()
        {
            yield return new Flight
            {
                Id = 1,
                ArrivalAirportId = 1,
                DepartureAirportId = 2,
                BasePrice = 20000,
                PlaneId = 1,
                Status = FlightStatus.Planned,
                ArrivalDate = DateTime.Now,
                DepartureDate = DateTime.Now.AddDays(-1),
            };
        }
        public static IEnumerable<Airport> InitAirports()
        {

            yield return new Airport { Id = 1, City = "Bruxelles - Zaventem", Code = "BRU", Country = "Belgium" };
            yield return new Airport { Id = 2, City = "Tokyo - Haneda", Code = "HND", Country = "Japan" };
        }
    }
}
