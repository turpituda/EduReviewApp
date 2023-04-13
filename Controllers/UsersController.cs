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
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        private readonly EduReviewAppContext _dbcontext;
        private readonly IConfiguration _config;
        public UsersController(ILogger<UsersController> logger, EduReviewAppContext dbcontext, IConfiguration config)
        {
            _logger = logger;
            _dbcontext = dbcontext;
            _config = config;
        }

        //[HttpGet("Admins")]
        //[Authorize(Roles = "a")]
        //public IActionResult AdminsEndpoint()
        //{
        //    var currentUser = GetCurrentUser();
        //    return Ok($"Hi {currentUser.username}. Role: {currentUser.user_type}");
        //}

        //private Users GetCurrentUser()
        //{
        //    var identity = HttpContext.User.Identity as ClaimsIdentity;
        //    if (identity != null)
        //    {
        //        var userClaims = identity.Claims;
        //        return new Users
        //        {
        //            username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
        //            email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
        //            user_type = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
        //        };
        //    }
        //    return null;
        //}



        // GET api/<UsersController>
        [HttpGet]
        [Authorize(Roles = "a")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _dbcontext.Users.ToListAsync());
        }

        // POST api/<UsersController>
        [HttpPost]
        [Authorize(Roles = "a")]
        public async Task<IActionResult> AddUser(Users users)
        {
            var user = new Users()
            {
                user_id = Guid.NewGuid(),
                username = users.username,
                email = users.email,
                password = users.password,
                user_type = users.user_type
            };
            await _dbcontext.Users.AddAsync(user);
            await _dbcontext.SaveChangesAsync();
            return Ok(user);
        }

        // PUT api/<UsersController>/id
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "a")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, Users users)
        {
            var user = await _dbcontext.Users.FindAsync(id);
            if (user != null) {
               user.username = users.username;
                user.email = users.email;  
                user.password = users.password;    
                user.user_type = users.user_type;

                await _dbcontext.SaveChangesAsync();
                return Ok(users);
            }
            return NotFound();
        }

        // GET api/<UsersController>/id
        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "a")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await _dbcontext.Users.FindAsync(id);
            if (user == null) {
                return NotFound();
            }
            return Ok(user);
        }

        // DELETE api/<UsersController>/id
        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "a")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await _dbcontext.Users.FindAsync(id);
            if (user != null)
            {
                _dbcontext.Remove(user);
                await _dbcontext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }
    }
}
