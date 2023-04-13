using EduReviewApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MyApp.Controllers
{        
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : Controller
    {
        private static IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<SubmissionController> _logger;
        private readonly EduReviewAppContext _dbcontext;
        private readonly IConfiguration _config;
        public FileUploadController(IWebHostEnvironment webHostEnvironment, ILogger<SubmissionController> logger, EduReviewAppContext dbcontext, IConfiguration config)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _dbcontext = dbcontext;
            _config = config;
        }
        [HttpPost]
        [Route("AddSubmission")]
        [AllowAnonymous]
        public async Task<string> Upload ([FromForm] Submission obj)
        {

            if (obj.files.Length > 0)
            {
                try
                {
                    if(!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Files\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Files\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_webHostEnvironment.WebRootPath+ "\\Files\\" + obj.files.FileName))
                    {
                        obj.files.CopyTo(filestream);
                        filestream.Flush();
                        return "\\Files\\"+obj.files.FileName;

                    }
                    
                }
                catch(Exception ex) 
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Upload Failed";
            }            
            var studentName = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Student studentId = await _dbcontext.Students.SingleOrDefaultAsync(p => p.Name == studentName);
            var SubmissionStatus = "";
            var submission = new Submission
            {
                SubmissionId = Guid.NewGuid(),
                StudentId = studentId.StudentId,
                SubmissionDate = DateTime.Now,
                SubmissionStatus = SubmissionStatus,
                SubmissionComment = "",
                FileName =obj.files.FileName
            };
        }
    }
}
