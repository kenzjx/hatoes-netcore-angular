using System;
using Beetsoft_Management_System.Data;
using Beetsoft_Management_System.Data.Entities;
using Beetsoft_Management_System.Models.Report.WorkingReport;
using Beetsoft_Management_System.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Beetsoft_Management_System.Controllers
{
    public class ReportController : BaseController
    {
        private readonly IWorkingReportRepository _service;
        
        private readonly ApplicationDbContext context;
        public ReportController(UserManager<User> userManager, IWorkingReportRepository service, ApplicationDbContext context) : base(userManager)
        {
            _service = service;
            this.context = context;
        }

        public class CreateWorking
        {
            public string userId {set;get;}


            public int projectId {set;get;}

            public int PositionId {set;get;}

            public float Time {set;get;}

            public DateTime Day {set;get;}

            public int Type {set;get;}

            public string Note {set;get;}

        }

        [HttpGet("WorkingReports/{id}")]
        public async Task<IActionResult> WorkingReports(string id, [FromQuery] WorkingParamters parameters)
        {
            var report = await _service.GetWorkingAsync(id, parameters);

            var metadata = new
            {
                report.TotalCount,
                report.PageSize,
                report.CurrentPage,
                report.TotalPages,
                report.HasNext,
                report.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(report);
        }

        [HttpPost("working-report")]
        public async Task<IActionResult> CreateWorkingReports(CreateWorking model)
        {
            var user = context.User.Where(u => u.Id.Equals(model.userId)).SingleOrDefault();
            if(user == null)
            {
                return NotFound();
            }
            var project = context.Projects.Where(p => p.Id.Equals(model.projectId)).SingleOrDefault();

            if(project ==null)
            {
                return NotFound();
            }

            var postion = context.Postions.Where(p => p.Id.Equals(model.PositionId)).SingleOrDefault();
            if(postion == null)
            {
                return NotFound();
            }

            var reportWorking = context.Reports.Include(r => r.ReportPositions);
            
            var report = new Report{
                UserId = model.userId,
                ProjectId = model.projectId,
                Time = model.Time,
                Date = DateTime.Now,
                Note = model.Note,
                Type = model.Type,
                User = user,
                // Project = project,
                ReportType = false

            };

             await context.Reports.AddAsync(report);

              await context.SaveChangesAsync();


            var reportId = await context.Reports.OrderBy(r => r.Id).Select(r => r.Id).LastAsync();


           var reportPosition =new ReportPosition{
                ReportId = reportId,
                // Report = report,
                // Position = postion,
                PostionId = postion.Id    
            };

           
            await context.ReportPositions.AddAsync(reportPosition);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}