using Beetsoft_Management_System.Data.Entities;
using Beetsoft_Management_System.Interface;
using Beetsoft_Management_System.Models.GoogleUser;
using Beetsoft_Management_System.Models.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Beetsoft_Management_System.Controllers
{
    public class AuthGGController : BaseController
    {
        private readonly IUserRepository userServices;

        private readonly UserManager<User> userManager;
        public AuthGGController(IUserRepository userServices, UserManager<User> userManager) : base(userManager)
        {
            this.userServices = userServices;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GoogleAuthenticate([FromBody] GoogleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var token = await userServices.AuthenticateGooleUserAsync(request);
            try
            {
                if (token != null)
                {
                    return Ok(token);
                }
                else return BadRequest();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ReFreshToken(TokenModel model)
        {
            return Ok();
        }

    }
}