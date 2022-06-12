namespace Beetsoft_Management_System.Systems
{
    public class UserProfileCreateRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Address { get; set; }

        public DateTime? Dob { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
