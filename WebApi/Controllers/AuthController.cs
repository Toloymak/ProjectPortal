using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Types.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private static string TestLogin = "Test user";
        private static string TestToken = "Empty";
        
        [HttpGet("[action]")]
        public IActionResult Me(string testKey)
        {
            var authToken =this.HttpContext.Request.Cookies["Authorization"];
            if (authToken != TestToken)
            {
                return Unauthorized();
            }
            
            return Ok(new PersonModel()
            {
                Login = TestLogin
            });
        }

        [HttpPost("[action]")]
        public IActionResult Login(LoginModel loginModel)
        {
            TestLogin = loginModel.Login;
            TestToken = Guid.NewGuid().ToString();

            HttpContext.Response.Cookies.Append("Authorization", TestToken, new CookieOptions()
            {
                Expires = DateTimeOffset.MaxValue
            });

            var loginResult = new LoginResultModel()
            {
                Person = new PersonModel()
                {
                    Login = TestLogin
                }
            };
            
            return Ok(loginResult);
        }
    }
}