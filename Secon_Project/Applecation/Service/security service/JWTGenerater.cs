using Applecation.DTOs.security;
using Domain.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Applecation.Service.security_service
{
    public class JWTGenerater
    {
        //private readonly JWTSitting jWTSitting;
        private readonly IConfiguration configuration;

        public JWTGenerater(IConfiguration configuration)
        {
            this.configuration = configuration;

        }

        public JWTResponse generateToken(Users user)
        {
            var jwt = configuration.GetSection("Jwt");

            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub,user.userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.email),
                new Claim("username",user.userName),
                new Claim(ClaimTypes.Email, user.email),
                new Claim(ClaimTypes.NameIdentifier, user.userId.ToString()),


            };
            if (user.userRoles != null)
            {
                foreach (var ur in user.userRoles)
                {
                    // assumes ur.role.roleName exists
                    if (ur.role != null)
                        claims.Add(new Claim(ClaimTypes.Role, ur.role.roleName));
                }
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expier = DateTime.UtcNow.AddMinutes(int.Parse(jwt["ExpMinutes"]!));

            var token = new JwtSecurityToken(
                issuer: jwt["Issuer"],
                audience: jwt["Aduience"],
                claims: claims,
                expires: expier,
                signingCredentials: creds
                );

            return  new JWTResponse
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresAuth = expier
            };


        }
    }
}
