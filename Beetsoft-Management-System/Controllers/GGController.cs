using Beetsoft_Management_System.Data.Entities;
using Beetsoft_Management_System.Interface;
using Beetsoft_Management_System.Models.GoogleUser;
using Beetsoft_Management_System.Models.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Beetsoft_Management_System.Controllers
{
<<<<<<< HEAD
    public class ggController : BaseController
=======
    public class GGController : BaseController
>>>>>>> origin/khaivm_loginGG
    {
        private readonly IGoogleRepository googleService;

        private readonly UserManager<User> userManager;
<<<<<<< HEAD
        public ggController(IGoogleRepository googleService, UserManager<User> userManager) : base(userManager)
=======
        public GGController(IGoogleRepository googleService, UserManager<User> userManager) : base(userManager)
>>>>>>> origin/khaivm_loginGG
        {
            this.googleService = googleService;
            this.userManager = userManager;
        }

        [AllowAnonymous]
<<<<<<< HEAD
        [HttpPost("login")]
        public async Task<IActionResult> Google(GoogleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
=======
        [HttpPost("/google")]
        public async Task<IActionResult> Google([FromBody] GoogleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();    
>>>>>>> origin/khaivm_loginGG
            }

            var token = await googleService.AuthenticateGooleUserAsync(request);
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