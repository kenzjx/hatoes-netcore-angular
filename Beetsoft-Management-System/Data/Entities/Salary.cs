
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beetsoft_Management_System.Data.Entities
{
    public class Salary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string HourlySalary { get; set; }

        public DateTime EffectiveDay { get; set; }

        public int? Status { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
