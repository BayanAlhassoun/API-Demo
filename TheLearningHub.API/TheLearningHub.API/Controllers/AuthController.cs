using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheLearningHub.Core.Data;
using TheLearningHub.Core.Service;

namespace TheLearningHub.API.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
        {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
            {
            _authService = authService;
            }

        [HttpPost]
        public IActionResult Login(Login login)
            {
            var token = _authService.Login(login);
            if (token == null)
                {
                return Unauthorized();
                }
            else
                {
                return Ok(token);
                }
                }
            
        }
    }
