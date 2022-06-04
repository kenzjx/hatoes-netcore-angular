using System.Net;
using Beetsoft_Management_System.Data.Entities;
using Beetsoft_Management_System.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Beetsoft_Management_System.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserRepository userService;
        public UserController(UserManager<User> userManager, IUserRepository userService ) : base(userManager)
        {
            this.userService = userService;
        }

        [HttpGet("/user-photo/{id:string?}", Name = "user-photo")]
        public async Task<IActionResult> UserPhoto(string id)
        {
            var (Data, type, name) = await userService.GetPhoto(id);
            return File(Data, type, name);
        }
    }
}