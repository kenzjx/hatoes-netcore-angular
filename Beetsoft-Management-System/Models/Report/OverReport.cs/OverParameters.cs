using Beetsoft_Management_System.Models.Query;

namespace Beetsoft_Management_System.Models.Report.OverReport
{
    public class OverParameters : QueryStringParameters
    {
        public OverParameters()
        {
            OrderBy = "Date desc";
        }

        public string Name {set;get;}
    }
}