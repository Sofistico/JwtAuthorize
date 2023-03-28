using JwtAuth.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuth.Controllers
{
    [Route("home")]
    public class HomeController
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Hi()
        {
            return new OkObjectResult("Hello!");
        }

        [AllowAnonymous]
        [HttpGet("Token")]
        public IActionResult GetToken(User user)
        {
            return new OkObjectResult(TokenGenService.GenerateToken(user));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult NotHi()
        {
            return new OkObjectResult($"Hi {nameof(Hi)}");
        }
    }
}
