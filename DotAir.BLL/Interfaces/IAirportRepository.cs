using DotAir.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAir.BLL.Interfaces
{
    public interface IAirportRepository
    {
        List<Airport> Search(string? keyword, string? isocode);
        Airport Add(Airport airport);
        void Remove(Airport airport);
        void Update(Airport airport);
        Airport? Find(params object[] id);
        Airport? FindWithFlights(int id);
    }
}
