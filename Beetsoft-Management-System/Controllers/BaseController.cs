using Beetsoft_Management_System.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Beetsoft_Management_System.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {      
            private readonly UserManager<User> userManager;

        public BaseController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
    }
}