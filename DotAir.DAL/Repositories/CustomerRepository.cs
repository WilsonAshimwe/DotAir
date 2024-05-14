using Be.KhunLy.EF.Repository;
using DotAir.BLL.Interfaces;
using DotAir.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotAir.DAL.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {

        public CustomerRepository(DotAirContext context) :base(context)
        {
        }

        public int Count(string prefix)
        {
            return _table.Count(
                c => c.Email.StartsWith(prefix)
            );
        }

        public Customer? FindWithBookings(int id)
        {
            return _table.Include(c => c.Bookings)
                .Where(c => c.Email != "")
                .FirstOrDefault(c => c.Id == id);
        }

        public List<Customer> Search(string? lastName, string? firstName, string? email, string? domain)
        {
            return _table
                .Include(c => c.Bookings)
                .Where(c => c.Email != "")
                .Where(c => lastName == null || c.LastName.StartsWith(lastName.Trim()))
                .Where(c => firstName == null || c.FirstName.StartsWith(firstName.Trim()))
                .Where(c => email == null || c.Email.StartsWith(email.Trim()))
                .Where(c => EF.Functions.Like(c.Email, "%@" + domain+"%"))
                .ToList();
        }

        public override Customer? Find(params object[] id) //[17]
        {
            return _table.FirstOrDefault(c => id.Contains(c.Id) && c.Email != "");
        }
    }
}
