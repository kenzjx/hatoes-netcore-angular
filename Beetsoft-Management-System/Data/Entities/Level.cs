using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beetsoft_Management_System.Data.Entities
{
    public class Level
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string LevelName { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<Recruitment> Recruitments { get; set; }

        public ICollection<UserOnboard> UserOnboards { get; set; }



    }
}
