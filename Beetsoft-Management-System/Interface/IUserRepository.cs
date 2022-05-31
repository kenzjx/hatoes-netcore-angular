using Beetsoft_Management_System.Data.Entities;
using Beetsoft_Management_System.Models.GoogleUser;

namespace Beetsoft_Management_System.Interface
{
    public interface IUserRepository
    {
        Task<string> AuthenticateGooleUserAsync(GoogleRequest request);
    }
}