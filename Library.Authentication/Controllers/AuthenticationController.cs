using Library.Authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.Authentication.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private IConfiguration _config;

        public AuthenticationController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] LoginModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            IActionResult response = Unauthorized();

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { jwt = tokenString });
            }

            return response;
        }

        private string BuildToken(LoginModel user)
        {
            var claims = new[]
{
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
