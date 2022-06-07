using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beetsoft_Management_System.Data.Entities
{
    public class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string LanguageName { get; set; }

        public ICollection<FrameWork> FrameWorks { get; set; }

        public ICollection<Recruitment> Recruitments { get; set; }

        public ICollection<UserOnboard> UserOnboards { get; set; }

    }
}
