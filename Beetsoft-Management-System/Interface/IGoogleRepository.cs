using Beetsoft_Management_System.Data.Entities;
using Beetsoft_Management_System.Models.GoogleUser;

namespace Beetsoft_Management_System.Interface
{
    public interface IGoogleRepository
    {
<<<<<<< HEAD
=======

>>>>>>> origin/khaivm_loginGG
        Task<string> AuthenticateGooleUserAsync(GoogleRequest request);
    }
}