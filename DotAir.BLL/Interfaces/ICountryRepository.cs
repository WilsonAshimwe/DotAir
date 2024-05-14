using DotAir.Domain.Entities;

namespace DotAir.BLL.Interfaces
{
    public interface ICountryRepository
    {
        public List<Country> FindAll();
    }
}
