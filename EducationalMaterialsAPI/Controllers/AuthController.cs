using EducationalMaterialsAPI.Controllers.Authentication;
using EducationalMaterialsAPI.Data.Repository.Users;
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
        private readonly IUsersRepo _usersRepo;
        private readonly IJwtAuth _jwtAuth;

        public AuthController(ILogger<AuthController> logger, IJwtAuth jwtAuth, IUsersRepo usersRepo)
        {
            _logger = logger;
            _usersRepo = usersRepo;
            _jwtAuth = jwtAuth;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authentication([FromBody] UserCredential userCredential)
        {
            _logger.LogInfo(null, nameof(Authentication));
            var token = await _jwtAuth.Authentication(userCredential.UserName, userCredential.Password, _usersRepo);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
