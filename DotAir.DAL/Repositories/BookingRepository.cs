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
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(DotAirContext context) : base(context)
        {
        }
    }
}
