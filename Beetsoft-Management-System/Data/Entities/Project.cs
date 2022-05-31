using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beetsoft_Management_System.Data.Entities
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]    
        public string ProjectName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Revenue { get; set; }

        public decimal PmEstimate { get; set; }

        public decimal BrseEstimate { get; set; }

        public decimal ComtorEstimate { get; set; }

        public decimal TestEstimate { get; set; }

        public decimal DeveloperEstimate { get; set; }

        [MaxLength(255)]    
        public string Description   { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        [ForeignKey("ProjectType")]
        public int ProjectTypeId { get; set; }

        public ProjectType ProjectType { get; set; }

        public ICollection<MemberProject> MemberProjects { get; set; }

        public ICollection<PmProject> PmProjects { get; set; }
    }
}
