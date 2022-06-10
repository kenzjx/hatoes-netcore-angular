using Beetsoft_Management_System.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beetsoft_Management_System.Data.Entities
{
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public float? Time { get; set; }

        public DateTime? Date { get; set; }

        [MaxLength(255)]
        public string? Note { get; set; }

        public Status? Status { get; set; }

        public WorkingType? Type { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public double? Rate { get; set; }

        public string UserId { set; get; }

        public int? ProjectId { set; get; }

        public bool ReportType { set; get; }

        [ForeignKey("Id")]
        public ICollection<ReportPosition> ReportPositions { get; set; }

        
        public Project Project {set;get;}


    }
}
