using Beetsoft_Management_System.Data;
using Beetsoft_Management_System.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Beetsoft_Management_System.Controllers
{
    public class ProjectController : BaseController
    {
        private readonly ApplicationDbContext context;
        public ProjectController(UserManager<User> userManager, ApplicationDbContext context) : base(userManager)
        {
            this.context = context;
        }

        public class ViewModel
        {
            public int Id { set; get; }

            public string Name { set; get;}
        }

        [HttpGet("projects")]
        public async Task<IActionResult> Projects()
        {
            
            // var result = await context.Projects.Where(p => p.MemberProjects.Any(j => j.UserId == id)).Select(p => new ViewModel { Id = p.Id, Name = p.ProjectName }).ToListAsync();
            var result = await context.Projects.Select(p => new ViewModel { Id = p.Id, Name = p.ProjectName }).ToListAsync();
            return Ok(result);
        }

        [HttpPost("project-create")]
        public async Task<IActionResult> ProjectC(CreateProject model)
        {
            await context.Projects.AddAsync(new Project
            {
                ProjectName = model.ProjectName
            });
            await context.SaveChangesAsync();
            return Ok();
        }


        public class CreateProject
        {
            public string ProjectName { set; get; }
        }
    }
}