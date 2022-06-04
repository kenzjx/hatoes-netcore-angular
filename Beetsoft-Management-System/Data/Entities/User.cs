using Beetsoft_Management_System.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beetsoft_Management_System.Data.Entities
{
    [Table(" Users")]
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime? Dob { get; set; }

        [MaxLength(50)]
        public string? Address { get; set; }

        public string? ImagePath { get; set; }

        public string? ImageExtension {set;get;}

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? CvLink { get; set; }

        public string? Company { get; set; }

        [ForeignKey("Level")]
        public int? LevelId { get; set; }

        public Level? Level { get; set; }

        [ForeignKey("Salary")]
        public int? SalaryId { get; set; }

        public Salary? Salary { set; get; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }

        [ForeignKey("Team")]
        public int? TeamId { get; set; }

        public Team? Team { get; set; }

        public Status Status { get; set; }

        public WorkingStatus WorkingStatus { get; set; }

        public ICollection<OffReport> OffReports { set; get; }

        public ICollection<MemberProject> MemberProjects { get; set; }

        public ICollection<PmProject> PmProjects { get; set; }

    }
}
