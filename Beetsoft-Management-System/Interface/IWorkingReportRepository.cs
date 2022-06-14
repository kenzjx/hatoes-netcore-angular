using Beetsoft_Management_System.Data;
using Beetsoft_Management_System.Data.Entities;
using Beetsoft_Management_System.Dtos.Report.Working;
using Beetsoft_Management_System.Interface;
using Beetsoft_Management_System.Models.Report.WorkingReport;
using Beetsoft_Management_System.Pagination;
using Beetsoft_Management_System.Systems;
using static Beetsoft_Management_System.Repository.WorkingReportRepository;

namespace Beetsoft_Management_System.Repository
{
    public interface IWorkingReportRepository : IRepositoryBase<Report>
    {
       Task<PagedList<WorkingView>> GetWorkingAsync(string id, WorkingParamters workingParameters);
       
       Task<Report> GetWorkingByIdAsync(int id);

        Task CreateAsync(CreateDto models);

        Task UpdateAsync(UpdateDto models);

        Task DeleteAsync(int id);
    }
}