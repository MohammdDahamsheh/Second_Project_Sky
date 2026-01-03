using Applecation.Repository.securityRepo;
using Applecation.DTOs.security;
using Domain.Entity;
using Infrastrucure;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Cryptography;
using Applecation.Response;

namespace Applecation.Service.security_service
{
    public class AuthService
    {
        private const int tokenLenght = 32;

        private readonly IUserRepo userRepo;
        private readonly PasswordService passwordService;
        private readonly JWTGenerater jwtGenerater;
        private readonly RoleRepo roleRepo;
        private readonly TenderContext context;
        private readonly RandomNumberGenerator RandomNumberGentrator = RandomNumberGenerator.Create();

        public AuthService(TenderContext context,RoleRepo roleRepo,IUserRepo userRepo, PasswordService passwordService, JWTGenerater jwtGenerater)
        {
            this.userRepo = userRepo;
            this.passwordService = passwordService;
            this.jwtGenerater = jwtGenerater;
            this.roleRepo = roleRepo;
            this.context = context;
        }

        public async Task<JWTResponse> login(LoginDTO loginDTO) {
            var user =await  userRepo.getByEmailAndRoleAsync(loginDTO.Email);
            if (user == null) {
                throw new Exception("No user with this email .....");
            }
            
            var checkPassword = passwordService.varify(user,loginDTO.Password);

            if (!checkPassword) {
                throw new Exception("The password is wrong ....");
            }
            return jwtGenerater.generateToken(user);
            
        }
        public async Task<JWTResponse> register(RegisterDTO registerDTO) {
            var user = await userRepo.getUserByEmail(registerDTO.email);

            if (user != null)
            {
                //throw new Exception("This email was used .....");
                var role = await (from ur in context.UserRoles where ur.userId==user.userId select ur.roleId).ToListAsync();
                if (role.Contains(registerDTO.roleId)) throw new Exception("The user have this role......");
               
            }

             
            var roles =await roleRepo.getRoleById(registerDTO.roleId);
            if (roles == null) {
                throw new Exception("No role with this Id ");
            }

            if (user == null)
            {

                var userTemp = new Users(
                     registerDTO.username,
                     registerDTO.password,
                     registerDTO.email,
                    registerDTO.phoneNumber

                );
            var hashedPassword = passwordService.hashing(userTemp, registerDTO.password);
            userTemp.userPassword=hashedPassword;

        
                await userRepo.addUserAsync(userTemp);
                var userRole = new UserRoles(userTemp.userId, roles.roleId);
                await userRepo.AddUserRoles(userRole);
                await context.SaveChangesAsync();
                var userCur = await userRepo.getByEmailAndRoleAsync(userTemp.email);



                return jwtGenerater.generateToken(userCur);

            }


            var Role = new UserRoles(user.userId, roles.roleId);
            await userRepo.AddUserRoles(Role);
            await context.SaveChangesAsync();
            var Cur = await userRepo.getByEmailAndRoleAsync(user.email);



            return jwtGenerater.generateToken(Cur);


        }
        public async Task<ForgetPasswordResponse> forgetPassword(string email) { 
            var user=await userRepo.getUserByEmail (email);
            if (user == null) {
                throw new Exception("No user with this email .....");
            }

            return new ForgetPasswordResponse
            {
                email = user.email,
                resetToken = generateRandomToken()
            };
        }
        public async Task<string> restPassword(restPasswordDTO restPasswordDTO) { 
            var user =await userRepo.getUserByEmail(restPasswordDTO.email);
            if (user == null)
            {
                throw new Exception("No user with this email .....");
            }
            await userRepo.UpdatePassword(user, passwordService.hashing(user, restPasswordDTO.Password));
            return "Password updated successfully";
        }
        public string generateRandomToken() {
            var massege=new byte[tokenLenght];
            RandomNumberGenerator.Fill(massege);
            return Convert.ToBase64String(massege);
        }
    
    
    }
}
