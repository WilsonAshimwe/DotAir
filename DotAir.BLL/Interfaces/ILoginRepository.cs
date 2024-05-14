using DotAir.Domain.Entities;

namespace DotAir.BLL.Interfaces
{
    public interface ILoginRepository
    {
        Login? Get(string email);
    }
}
