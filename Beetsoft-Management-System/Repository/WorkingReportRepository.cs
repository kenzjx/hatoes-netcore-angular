
using System.Linq;
using System.Linq.Expressions;
using Beetsoft_Management_System.Data.Entities;
using Beetsoft_Management_System.Dtos.Report.Working;
using Beetsoft_Management_System.Models.Report.WorkingReport;
using Beetsoft_Management_System.Pagination;
using Beetsoft_Management_System.Data;
using Beetsoft_Management_System.Helpers;
using Microsoft.EntityFrameworkCore;
using Beetsoft_Management_System.Data.Enums;
using System.Text;
using System.Linq.Dynamic.Core;

namespace Beetsoft_Management_System.Repository
{
    public class WorkingReportRepository : RepositoryBase<Report>, IWorkingReportRepository
    {

        private readonly WorkingSort _sortReport;

        private readonly ApplicationDbContext context;
        public WorkingReportRepository(ApplicationDbContext context, WorkingSort sortReport) : base(context)
        {
            _sortReport = sortReport;
            this.context = context;
        }

        public Task CreateAsync(CreateDto models)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedList<WorkingQuery>> GetWorkingAsync(WorkingParamters workingParameters)
        {
            var report = context.Reports.Include(c => c.Project).Include(r => r.ReportPositions).ThenInclude(r => r.Position).Select(r => new WorkingQuery
            {
                Id = r.Id,
                Time = (float)r.Time,
                Day = (DateTime)r.Date
            ,
                Type = (WorkingType)r.Type,
                Note = r.Note,
                Status = (Status)r.Status,
                Project = r.Project,
                positionNames = r.ReportPositions.Select(r => r.Position.PositionName)
            }).AsNoTracking();

            var reportSeach = SearchBy(report, workingParameters.Name);
            
            var sortedReport = _sortReport.AppySort(reportSeach, workingParameters.OrderBy);

            return await PagedList<WorkingQuery>.ToPagedList(sortedReport, workingParameters.PageNumber, workingParameters.PageSize);
        }

        private IQueryable<WorkingQuery> SearchBy(IQueryable<WorkingQuery> report, string name)
        {
            if (!report.Any() || string.IsNullOrEmpty(name)) return report;
            return report.Where(o => o.Project.ProjectName.ToLower().Contains(name.Trim().ToLower()) || o.positionNames.Contains(name));
        }

        

        public async Task<Report> GetWorkingByIdAsync(int id)
        {
            return await FindByCondition(rp => rp.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public Task UpdateAsync(UpdateDto models)
        {
            throw new NotImplementedException();
        }


    }
}