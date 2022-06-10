using Beetsoft_Management_System.Models.Query;

namespace Beetsoft_Management_System.Models.Report.WorkingReport
{
    public class WorkingParamters : QueryStringParameters
    {
        public WorkingParamters()
        {
            OrderBy = "Date desc";
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Name { get; set; }
        public string? OrderBy { get; set; }
    }
}