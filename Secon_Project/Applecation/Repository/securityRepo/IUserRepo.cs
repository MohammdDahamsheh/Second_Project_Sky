using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.Repository.securityRepo
{
    internal interface IUserRepo
    {
        Task<Users> getUserByEmail(string email);
        Task<Users>addUserAsync(Users user);
    }
}
