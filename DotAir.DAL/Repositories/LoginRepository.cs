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
    public class LoginRepository : BaseRepository<Login>, ILoginRepository
    {
        public LoginRepository(DotAirContext context) : base(context)
        {
        }

        public Login? Get(string email)
        {
            return _table.FirstOrDefault(l => l.Email == email);
        }
    }
}
