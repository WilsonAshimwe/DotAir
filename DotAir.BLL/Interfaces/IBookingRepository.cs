using DotAir.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAir.BLL.Interfaces
{
    public interface IBookingRepository
    {
        Booking Add(Booking b);
    }
}
