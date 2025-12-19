using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.Service.security_service
{
    public class PasswordService
    {
        private readonly PasswordHasher<Users>hasher=new PasswordHasher<Users>();

        public string hashing(Users user,string password) {
            return hasher.HashPassword(user, password);
        }
        public bool varify(Users user,string password) {
            return hasher.VerifyHashedPassword(user, user.userPassword, password) == PasswordVerificationResult.Success;
        }
    }
}
