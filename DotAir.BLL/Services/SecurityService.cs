using DotAir.BLL.Interfaces;
using DotAir.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace DotAir.BLL.Services
{
    public class SecurityService(ILoginRepository _loginRepository, IPasswordHasher _passwordHasher)
    {
        public Login Login(string email, string password)
        {
            Login? l = _loginRepository.Get(email);
            if (l == null)
            {
                throw new ValidationException("Aucun user avec cet email");
            }
            if(!_passwordHasher.Hash(l.Email + password).SequenceEqual(l.Password))
            {
                throw new ValidationException("pwd non valide");
            }
            return l;
        }
    }
}
