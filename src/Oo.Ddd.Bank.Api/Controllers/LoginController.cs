using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oo.Ddd.Bank.Api.Dto;

namespace Oo.Ddd.Bank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody]LoginReq loginRequest)
        {
            if (loginRequest == null || loginRequest.NumeroDaConta == 0 || string.IsNullOrEmpty(loginRequest.Senha))
            {
                return BadRequest("Invalid login request.");
            }
            
            
            if (loginRequest.NumeroDaConta == 1 && loginRequest.Senha == "senha123")
            {
                return Ok(new { Message = "Login successful", Token = "fake-jwt-token" });
            }

            return Unauthorized("Invalid username or password.");
        }
    }
}
