using Beetsoft_Management_System.Data.Entities;
using Beetsoft_Management_System.Models.Report.WorkingReport;
using Beetsoft_Management_System.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Beetsoft_Management_System.Controllers
{
    public class ReportController : BaseController
    {
        private readonly IWorkingReportRepository _service;
        public ReportController(UserManager<User> userManager, IWorkingReportRepository service ) : base(userManager)
        {
            _service = service;
        }

        [HttpGet("WorkingReports")]
        public async Task<IActionResult> WorkingReports([FromQuery]WorkingParamters parameters)
        {
            var report = await _service.GetWorkingAsync(parameters);

            var metadata  = new 
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
    }
}