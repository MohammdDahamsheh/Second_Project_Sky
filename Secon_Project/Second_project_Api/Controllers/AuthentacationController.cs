using Applecation.Service.security_service;
using Applecation.DTOs.security;
using Microsoft.AspNetCore.Mvc;

namespace Second_project_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthentacationController : ControllerBase
    {
        private readonly AuthService authService;

        public AuthentacationController(AuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> register([FromBody] RegisterDTO registerDTO)
        {
            var result = await authService.register(registerDTO);
            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> login([FromBody] LoginDTO loginDTO)
        {
            var result = await authService.login(loginDTO);
            return Ok(result);
        }
        [HttpPost("forgetPassword")]
        public async Task<IActionResult> forgetPassword([FromBody]string email) { 
            var result = await authService.forgetPassword(email);
            return Ok(result);
        }
        [HttpPost("restPassword")]
        public async Task<IActionResult> restPassword([FromBody] restPasswordDTO restPasswordDTO)
        {
            var result = await authService.restPassword(restPasswordDTO);
            return Ok(result);

        }
    }
}
