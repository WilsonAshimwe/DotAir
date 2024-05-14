using Be.KhunLy.EF.Repository;
using DotAir.BLL.Interfaces;
using DotAir.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAir.DAL.Repositories
{
    public class AirportRepository : BaseRepository<Airport>, IAirportRepository
    {
        public AirportRepository(DotAirContext context) : base(context)
        {
        }

        public List<Airport> Search(string? keyword, string? isocode)
        {
            return _table
                .Where(c => keyword == null || c.City.StartsWith(keyword) || c.Code.StartsWith(keyword))
                .Where(c => isocode == null || c.Country == isocode)
                .ToList();
        }

        public Airport? FindWithFlights(int id)
        {
            return _table
                .Include(a => a.ArrivalFlights)
                .Include(a => a.DepartFlights)
                .FirstOrDefault(a => a.Id == id);
        }
    }
}
