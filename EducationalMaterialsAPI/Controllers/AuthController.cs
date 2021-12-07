using EducationalMaterialsAPI.Controllers.Authentication;
using EducationalMaterialsAPI.Logger.Extensions;
using EducationalMaterialsAPI.Model.Auth;
using Microsoft.AspNetCore.Mvc;

namespace EducationalMaterialsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IJwtAuth _jwtAuth;

        public AuthController(ILogger<AuthController> logger, IJwtAuth jwtAuth)
        {
            _logger = logger;
            _jwtAuth = jwtAuth;
        }

        [HttpPost("login")]
        public IActionResult Authentication([FromBody] UserCredential userCredential)
        {
            _logger.LogInfo(null, nameof(Authentication));
            var token = _jwtAuth.Authentication(userCredential.UserName, userCredential.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
