using Applecation.Service.security_service;
using Applecation.DTOs.security;
using Microsoft.AspNetCore.Mvc;

namespace Second_project_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthentacationController:ControllerBase
    {
        private readonly AuthService authService;

        public AuthentacationController(AuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> register([FromBody]RegisterDTO registerDTO) {
            var result =await authService.register(registerDTO);
            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> login([FromBody]LoginDTO loginDTO) { 
            var result=await authService.login(loginDTO);
            return Ok(result);
        }



    }
}
