using Domain.DTOs.security;
using Domain.Entity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.Service.security_service
{
    public class JWTGenerater
    {
        private readonly JWTSitting jWTSitting;

        public JWTGenerater(JWTSitting jWTSitting)
        {
            this.jWTSitting = jWTSitting;
        }

        public JWTResponse generateToken(Users user)
        {

            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub,user.userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.email),
                new Claim("username",user.userName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jWTSitting.key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expier = DateTime.UtcNow.AddMinutes(jWTSitting.expMinutes);

            var token = new JwtSecurityToken(
                issuer: jWTSitting.issuer,
                audience: jWTSitting.audience,
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
