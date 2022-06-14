namespace Beetsoft_Management_System.Data.Entities
{
    public class ReportPosition
    {
        public Position? Position{set;get;}
        public int PostionId { get; set; }

        public int ReportId { get; set; }   

        public Report? Report {set;get;}
    }
}
