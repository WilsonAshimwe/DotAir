using DotAir.BLL.Interfaces;
using DotAir.Domain.Entities;

namespace DotAir.BLL.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPasswordHasher _passwordHasher;

        public CustomerService(ICustomerRepository customerRepository, IPasswordHasher passwordHasher)
        {
            _customerRepository = customerRepository;
            _passwordHasher = passwordHasher;
        }

        public void Delete(int id)
        {
            Customer? customer = _customerRepository.FindWithBookings(id);
            if (customer is null)
            {
                throw new KeyNotFoundException();
            }
            // pas de reservarsion
            if (!customer.Bookings.Any()) 
            {
                _customerRepository.Remove(customer);
            }
            else
            {
                customer.Email = "";
                _customerRepository.Update(customer);
            }
        }

        public Customer Register(string lastName, string firstName, string password, DateTime birthDate)
        {
            string prefix = (firstName[0] + "." + lastName).ToLower();
            int count = _customerRepository.Count(prefix);
            if(count > 0)
            {
                prefix += count;
            }
            string email = prefix + "@dotair.com";
            byte[] hash = _passwordHasher.Hash(email + password);
            return _customerRepository.Add(new Customer
            {
                LastName = lastName,
                FirstName = firstName,
                Email = email,
                Password = hash,
                BirthDate = birthDate
            });
        }

        public List<Customer> Search(string? lastName, string? firstName, string? email, string? domain)
        {
            return _customerRepository.Search(lastName, firstName, email, domain);
        }

        public void Update(int id, string lastName, string firstName, string? password)
        {
            Customer? customer = _customerRepository.Find(id);
            if(customer is null || customer.Email == "")
            {
                throw new KeyNotFoundException();
            }
            customer.LastName = lastName;
            customer.FirstName = firstName;
            if(password != null)
            {
                customer.Password = _passwordHasher.Hash(customer.Email + password);
            }
            _customerRepository.Update(customer);
        }
    }
}
