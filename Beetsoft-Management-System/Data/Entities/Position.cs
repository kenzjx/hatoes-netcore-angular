using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beetsoft_Management_System.Data.Entities
{
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string PositionName { get; set; }

        [ForeignKey("Id")]
        public ICollection<ReportPosition> ReportPositions { get; set; }

        public ICollection<Recruitment> Recruitments { get; set; }

        public ICollection<UserOnboard> UserOnboards { get; set; }
    }
}
