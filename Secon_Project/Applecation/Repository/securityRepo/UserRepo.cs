using Domain.Entity;
using Infrastrucure;
using Microsoft.EntityFrameworkCore;


namespace Applecation.Repository.securityRepo
{
    public class UserRepo : IUserRepo
    {
        private readonly TenderContext context;

        public UserRepo(TenderContext context)
        {
            this.context = context;
        }

        public async Task<Users> addUserAsync(Users user)
        {
          var userAdd= await context.Users.AddAsync(user);
            return userAdd.Entity;

        }

        public async Task<Users> getUserByEmail(string email)
        {
            var user = await (from u in context.Users
                              where email == u.email
                              select u
                                ).FirstOrDefaultAsync();
           
            return  user;
        }
    }
}
