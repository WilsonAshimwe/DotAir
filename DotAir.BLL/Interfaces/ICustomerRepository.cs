using DotAir.Domain.Entities;

namespace DotAir.BLL.Interfaces
{
    public interface ICustomerRepository
    {
        Customer Add(Customer customer);
        int Count(string prefix);
        Customer? Find(params object[] id);
        Customer? FindWithBookings(int id);
        void Remove(Customer customer);
        List<Customer> Search(string? lastName, string? firstName, string? email,string? domain);
        void Update(Customer customer);
    }
}
