using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beetsoft_Management_System.Data.Entities
{
    public class UserOnboard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [ForeignKey("Postion")]
        public int PostionId { get; set; }

        public Position Postion { get; set; }

        public DateTime OnBoardDate { get; set; }

        [ForeignKey("Level")]
        public int LevelId { get; set; }

        public Level Level { get; set; }

        [ForeignKey("Language")]
        public int LanguageId { get; set; }

        public Language Language  { get; set; }

        public string Note { get; set; }

    }
}
