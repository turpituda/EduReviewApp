using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyApp.Models;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EduReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        private readonly EduReviewAppContext _dbcontext;
        private readonly IConfiguration _config;
        public LoginController(ILogger<UsersController> logger, EduReviewAppContext dbcontext, IConfiguration config)
        {
            _logger = logger;
            _dbcontext = dbcontext;
            _config = config;
        }

        //Login
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }

            return NotFound("User not found.");
        }

        private string Generate(Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("Jwt:Key")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.username),
                new Claim(ClaimTypes.Email, user.email),
                new Claim(ClaimTypes.Role, user.user_type)
            };

            var token = new JwtSecurityToken(_config.GetValue<string>("Jwt:Issuer"),
                                 _config.GetValue<string>("Jwt:Audience"),
                                 claims,
                                 expires: DateTime.Now.AddMinutes(15),
                                 signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private Users Authenticate(UserLogin userLogin)
        {
            var currentUser = _dbcontext.Users.FirstOrDefault(o => o.username == userLogin.username && o.password == userLogin.password);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }
    }
}