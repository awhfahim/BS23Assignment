using BS23Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BS23Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration _configuration) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Registration(UserRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                await model.OnPostAsync();
                var response = new RegistrationResponseModel { Username = model.UserName,
                    Message = "Congrats You have been Successfully Registered" };
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                if(await model.LoginAsync())
                {
                    var token = CreateToken(model.Username);
                    return Ok(new {token, model.Username});
                }
            }
            return BadRequest();
        }

        private string CreateToken(string username)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
