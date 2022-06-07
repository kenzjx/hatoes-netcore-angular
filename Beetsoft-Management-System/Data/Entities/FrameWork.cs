using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beetsoft_Management_System.Data.Entities
{
    [Table("FrameWorks")]
    public class FrameWork
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Language")]
        public int LanguagueId { get; set; }

        public Language Language { get; set; }  

        [Required]
        [MaxLength(255)]
        public string FrameWorkName { get; set; }


    }
}
