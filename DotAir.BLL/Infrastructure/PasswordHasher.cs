using DotAir.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DotAir.BLL.Infrastructure
{
    public class PasswordHasher : IPasswordHasher
    {
        public byte[] Hash(string password)
        {
            return SHA512.HashData(Encoding.UTF8.GetBytes(password));
        }
    }
}
