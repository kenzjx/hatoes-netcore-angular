
using System;
using System.Linq;
using System.Linq.Expressions;
using Beetsoft_Management_System.Data.Entities;
using Beetsoft_Management_System.Dtos.Report.Working;
using Beetsoft_Management_System.Models.Report.WorkingReport;
using Beetsoft_Management_System.Pagination;
using Beetsoft_Management_System.Data;
using Beetsoft_Management_System.Helpers;
using Microsoft.EntityFrameworkCore;

using System.Text;
using System.Linq.Dynamic.Core;
using Beetsoft_Management_System.Systems;

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

        public async Task<PagedList<WorkingView>> GetWorkingAsync(string id, WorkingParamters workingParameters)
        {
            var reportTest = context.Reports.Where(p => p.ReportType == false && p.UserId == id).Select(r => new WorkingView
            {
                Id = r.Id,
                Time = r.Time,
                Date = r.Date,
                Note = r.Note,
                Type = r.Type,
                Status = r.Status,
                ProjectName = r.Project.ProjectName,
                ProjectId = (int)r.ProjectId,
                PositionId = r.ReportPositions.Where(r => r.PostionId == r.Report.PositionId).Select(r => r.PostionId).FirstOrDefault(),
                PositionName = r.ReportPositions.Where(r => r.PostionId == r.Report.PositionId).Select(r => r.Position.PositionName).FirstOrDefault()
            }).AsNoTracking();

            var reportSeach = SearchBy(reportTest, workingParameters.Name);

            var sortedReport = _sortReport.AppySort(reportSeach, workingParameters.OrderBy);

            return await PagedList<WorkingView>.ToPagedList(sortedReport, workingParameters.PageNumber, workingParameters.PageSize);
        }

        private IQueryable<WorkingView> SearchBy(IQueryable<WorkingView> report, string name)
        {
            if (!report.Any() || string.IsNullOrEmpty(name)) return report;
            return report.Where(o => o.ProjectName.ToLower().Contains(name.Trim().ToLower()));
        }



        public async Task<Report> GetWorkingByIdAsync(int id)
        {
            return await FindByCondition(rp => rp.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public Task UpdateAsync(UpdateDto models)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedList<WorkingView>> GetWorkingManageAsync(WorkingParamters workingParameters)
        {
            var reportTest = context.Reports.Where(p => p.ReportType == false).Select(r => new WorkingView
            {
                Id = r.Id,
                Time = r.Time,
                Date = r.Date,
                Note = r.Note,
                Type = r.Type,
                Status = r.Status,
                ProjectName = r.Project.ProjectName,
                ProjectId = (int)r.ProjectId,
                PositionId = r.ReportPositions.Where(r => r.PostionId == r.Report.PositionId).Select(r => r.PostionId).FirstOrDefault(),
                PositionName = r.ReportPositions.Where(r => r.PostionId == r.Report.PositionId).Select(r => r.Position.PositionName).FirstOrDefault()
            }).AsNoTracking();

            var reportSeach = SearchBy(reportTest, workingParameters.Name);

            var sortedReport = _sortReport.AppySort(reportSeach, workingParameters.OrderBy);

            return await PagedList<WorkingView>.ToPagedList(sortedReport, workingParameters.PageNumber, workingParameters.PageSize);
        }
    }
}