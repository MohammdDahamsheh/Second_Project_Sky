using Domain.DTOs.security;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.Service.security_service
{
    public interface IJWTGenerater
    {
        Task<JWTResponse> generateToken(Users user);
    }
}
