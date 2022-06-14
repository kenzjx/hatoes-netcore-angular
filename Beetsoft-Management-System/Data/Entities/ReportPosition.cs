using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beetsoft_Management_System.Data.Entities
{
    public class ReportPosition
    {
        [Key]
        public int Id { set; get; }
        public Position Position{set;get;}
        public int PostionId { get; set; }

        public int ReportId { get; set; }   

        public Report Report {set;get;}
    }
}
