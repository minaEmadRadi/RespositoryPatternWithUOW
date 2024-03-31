using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core.Models;
using System.Threading.Tasks;
using RepositoryPatternWithUOW.Core.Dtos;
using RepositoryPatternWithUOW.Core.Interfaces;

namespace RepositoryPatternWithUOW.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Customer> _userManager;
        private readonly IAuthService _auth;

        public AuthController(UserManager<Customer> userManager, IAuthService auth)
        {
            _userManager = userManager;
            _auth = auth;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var token = await _auth.GenerateJwtTokenAsync(user);

                return Ok(new { token = token });
            }
            return Unauthorized();
        }
    }

}
