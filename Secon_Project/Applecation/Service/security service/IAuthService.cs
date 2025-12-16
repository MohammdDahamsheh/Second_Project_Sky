using Domain.DTOs.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applecation.Service.security_service
{
    public interface IAuthService
    {
        Task<JWTResponse>login(LoginDTO loginDTO);
        Task<JWTResponse>register(RegisterDTO registerDTO);
    }
}
