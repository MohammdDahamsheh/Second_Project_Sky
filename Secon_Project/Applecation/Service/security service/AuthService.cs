using Applecation.Repository.securityRepo;
using Domain.DTOs.security;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.Service.security_service
{
    public class AuthService
    {
        private readonly IUserRepo userRepo;
        private readonly PasswordService passwordService;
        private readonly JWTGenerater jwtGenerater;

        public AuthService(IUserRepo userRepo, PasswordService passwordService, JWTGenerater jwtGenerater)
        {
            this.userRepo = userRepo;
            this.passwordService = passwordService;
            this.jwtGenerater = jwtGenerater;
        }

        public async Task<JWTResponse> login(LoginDTO loginDTO) {
            var user =await  userRepo.getUserByEmail(loginDTO.Email);
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
            var user = userRepo.getUserByEmail(registerDTO.email);
            if (user != null) {
                throw new Exception("This email was used .....");
            }
            var userTemp = new Users(
                 registerDTO.username,
                 registerDTO.password,
                 registerDTO.email,
                registerDTO.phoneNumber
            );
            var hashedPassword = passwordService.hashing(userTemp, registerDTO.password);
            userTemp.userPassword=hashedPassword;

             await userRepo.addUserAsync(userTemp);

            return jwtGenerater.generateToken(userTemp);



        }
    }
}
