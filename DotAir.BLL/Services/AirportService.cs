using DotAir.BLL.Interfaces;
using DotAir.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAir.BLL.Services
{
    public class AirportService(IAirportRepository _airportRepository)
    {
        public void Update(int id, string city, string country, string code)
        {
            Airport? airport = _airportRepository.Find(id);
            if (airport is null) 
            {
                throw new KeyNotFoundException();
            }
            airport.City = city;
            airport.Country = country;
            airport.Code = code;
            _airportRepository.Update(airport);
        }

        public void Delete(int id)
        {
            Airport? airport = _airportRepository.FindWithFlights(id);
            if (airport is null)
            {
                throw new KeyNotFoundException();
            }
            if(airport.DepartFlights.Any() || airport.ArrivalFlights.Any())
            {
                throw new ValidationException();
            }
            _airportRepository.Remove(airport);
        }

        public Airport Add(string city, string country, string code)
        {
            return _airportRepository.Add(new Airport
            {
                City = city,
                Country = country,
                Code = code
            });
        }

        public List<Airport> Search(string? keyword, string? isocode) 
        {
            return _airportRepository.Search(keyword, isocode);
        }
    }
}
