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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using EduReviewApp.Controllers;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace EduReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {

        private readonly ILogger<SubmissionController> _logger;
        private readonly EduReviewAppContext _dbcontext;
        private readonly IConfiguration _config;
        public SubmissionController(ILogger<SubmissionController> logger, EduReviewAppContext dbcontext, IConfiguration config)
        {
            _logger = logger;
            _dbcontext = dbcontext;
            _config = config;
        }
        // GET: SubmissionController
        [HttpGet]
        [Authorize(Roles = "a, p")]
        public async Task<IActionResult> GetAllSubmissions()
        {
            return Ok(await _dbcontext.Submissions.ToListAsync());
        }

        // GET: SubmissionController/Details/5
        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "a, p, s")]
        public async Task<IActionResult> GetSubmission([FromRoute] Guid id)
        {
            var submission = await _dbcontext.Submissions.FindAsync(id);
            if (submission == null)
            {
                return NotFound();
            }
            return Ok(submission);
        }
        // POST: CoursesController/Create
        [HttpPost]
        [Authorize(Roles = "p, s, a")]
        //[AllowAnonymous]
        public async Task<IActionResult> AddCourse(Course course)
        {
            var user_name = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Professor professor = await _dbcontext.Professors.SingleOrDefaultAsync(p => p.Name == user_name);


            var coursevar = new Course()
            {
                CourseId = Guid.NewGuid(),
                CourseName = course.CourseName,
                ProfessorId = professor.ProfessorId
            };

            await _dbcontext.Courses.AddAsync(coursevar);
            await _dbcontext.SaveChangesAsync();
            return Ok(coursevar);
        }

    }
}
