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
           await context.SaveChangesAsync();
            return userAdd.Entity;

        }

        public async Task AddUserRoles(UserRoles userRole)
        {
            await context.UserRoles.AddAsync(userRole);
            await context.SaveChangesAsync();
            
        }

        public async Task<Users> getByEmailAndRoleAsync(string email)

        {
            var userTemp = await context.Users.Include(u => u.userRoles).ThenInclude(u => u.role).FirstOrDefaultAsync(u => u.email == email);
            if (userTemp == null) { throw new Exception("No user with this email"); }
            return userTemp;

        }
        public async Task<Users> getUserByEmail(string email)
        {
            var user = await (from u in context.Users
                              where email == u.email
                              select u
                                ).FirstOrDefaultAsync();
            //if (user == null) { throw new Exception("No user with this email"); }
           
            return user;
        }

        public Task UpdatePassword(Users user, string newPassword)
        {
            user.userPassword = newPassword;
            context.Users.Update(user);
            return context.SaveChangesAsync();
        }
    }
}
