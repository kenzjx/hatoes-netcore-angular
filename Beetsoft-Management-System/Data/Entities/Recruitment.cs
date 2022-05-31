using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beetsoft_Management_System.Data.Entities
{
    public class Recruitment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int SalaryMax { get; set; }

        public int SalaryMin { get; set; }

        public DateTime DatePublis { get; set; }

        public DateTime? DateOnboard { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }

        public Language Language { get; set; }

        [ForeignKey("Postion")]
        public int PostionId { get; set; }

        public Position Postion { get; set; }    

        public int? Quantity { get; set; }

        [ForeignKey("Level")]
        public int LevelId { set; get; }

        public Level Level { set; get; }

        public string Onboard { set; get; }

        [MaxLength(255)]
        public string? Description { set; get; } 

    }
}
