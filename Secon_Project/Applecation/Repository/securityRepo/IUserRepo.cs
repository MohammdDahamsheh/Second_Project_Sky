using Domain.Entity;


namespace Applecation.Repository.securityRepo
{
    public interface IUserRepo
    {
        Task<Users> getUserByEmail(string email);
        Task<Users>addUserAsync(Users user);
        Task<Users>getByEmailAndRoleAsync(string email);
        Task AddUserRoles(UserRoles userRole);
    }
}
