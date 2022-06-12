using Beetsoft_Management_System.Data.Enums;

namespace Beetsoft_Management_System.Systems
{
    public class UserViewModel
    {

        public string Email { get; set; }

        public string DisplayName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public TypeUser Type { get; set; }

        public string Role { get; set; }

        public string Department { get; set; }

        public Status Status { get; set; }
    }
}
