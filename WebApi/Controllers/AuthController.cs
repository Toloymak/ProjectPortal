using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Types.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthService _jwtAuthService;
        private readonly ILogger<AuthController> _logger;
        
        public const string AuthToken = "Authorization";

        public AuthController(IJwtAuthService jwtAuthService, ILogger<AuthController> logger)
        {
            _jwtAuthService = jwtAuthService;
            _logger = logger;
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Login([FromBody] LoginModel inputDto)
        {
            var user = new UserModel();

            if (user == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserId.ToString()),
            };

            var jwtResult = _jwtAuthService.GenerateToken(inputDto.Login, claims, DateTime.Now);
            _logger.Log(LogLevel.Information, $"{inputDto.Login} has been logged");

            HttpContext.Response.Cookies.Append(AuthToken, jwtResult.AccessToken, new CookieOptions()
            {
                Expires = jwtResult.AuthTokenMetadata.ExpireAt
            });

            return Ok(new PersonModel()
            {
                Login = jwtResult.AuthTokenMetadata.UserName,
            });
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Registration(RegistrationModel dto)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Recovery()
        {
            throw new NotImplementedException();
        }

        [HttpGet("[action]")]
        [Authorize]
        public IActionResult Me(string testKey)
        {
            return Ok(new PersonModel()
            {
                Login = "TestLogin"
            });
        }
    }
}