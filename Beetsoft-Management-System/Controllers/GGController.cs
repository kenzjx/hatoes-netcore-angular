using System.Security.Claims;
using System.Net.Http;
using Beetsoft_Management_System.Data.Entities;
using Beetsoft_Management_System.Interface;
using Beetsoft_Management_System.Models.GoogleUser;
using Beetsoft_Management_System.Models.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Beetsoft_Management_System.Controllers
{

    public class ggController : BaseController

    {

       private readonly ILogger _logger;
        private readonly IGoogleRepository googleService;

        private readonly UserManager<User> userManager;

        public ggController(IGoogleRepository googleService, UserManager<User> userManager, ILogger<ggController> logger) : base(userManager)

        {
            this._logger = logger;
            this.googleService = googleService;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        
        [HttpPost("/google")]
        public async Task<IActionResult> Google([FromBody] GoogleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

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

        
        [HttpGet("test")]
        public async Task<IActionResult> Get()
        {
             var user = User?.Claims.ToList();
        //    _logger.LogWarning(user);
           return Ok(user);
        }
    }
}