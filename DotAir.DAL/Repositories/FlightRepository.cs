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
    public class FlightRepository : BaseRepository<Flight>, IFlightRepository
    {
        public FlightRepository(DotAirContext context) : base(context)
        {
        }

        public Flight? FindWithBookingsAndPlane(int id)
        {
            return _table
                .Include(f => f.ReturnBookings)
                .Include(f => f.DepartureBookings)
                .Include(f => f.ArrivalAirport)
                .Include(f => f.DepartureAirport)
                .Include(f => f.Plane)
                .FirstOrDefault(f => f.Id == id);
        }
    }
}
