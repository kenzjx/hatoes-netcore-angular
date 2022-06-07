using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beetsoft_Management_System.Data.Entities
{
    public class MemberProject
    {
      
        public  int ProjectId { get; set; }

        public string UserId { get; set; }

        public Project Project { get; set; }

        public User User { get; set; }


    }
}
