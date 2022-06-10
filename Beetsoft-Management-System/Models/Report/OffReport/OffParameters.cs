using Beetsoft_Management_System.Models.Query;

namespace Beetsoft_Management_System.Models.Report.OffReport
{
    public class OffParameters : QueryStringParameters
    {
        public OffParameters()
        {
            OrderBy = "Date desc";
        }

        public string Name {set;get;}
    }
}