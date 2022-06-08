using System.Net;
using Beetsoft_Management_System.Data;
using Beetsoft_Management_System.Data.Entities;
using Beetsoft_Management_System.Interface;
using Beetsoft_Management_System.Systems;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Beetsoft_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        private readonly ApplicationDbContext _context;

        public UserController(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;

        }

        [Route("ProfileUser/{id}")]
        [HttpGet]
        public async Task<IActionResult> ProfileUser(string id)
        {
            var userProfile = await _userManager.FindByIdAsync(id);

            if (id == null)
                return NotFound();

            var userProfileVm = new UserProfileViewModel()
            {
                Id = userProfile.Id,
                Email = userProfile.Email,
                Address = userProfile.Address,
                Dob = userProfile.Dob,
                FirstName = userProfile.FirstName,
                LastName = userProfile.LastName,
                ImagePath = userProfile.ImagePath,
                PhoneNumber = userProfile.PhoneNumber
            };

            return Ok(userProfileVm);

        }

        [Route("UpdateProfileUser/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProfileUser(string id, [FromBody] UserProfileCreateRequest request)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;
            user.Address = request.Address;
            user.Dob = request.Dob;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);

        }

        [Route("UploadAvatar")]
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(IFormFile myfile)
        {
            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files.First();
            var folderName = Path.Combine("Uploads", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = Path.GetFileNameWithoutExtension(myfile.FileName) + "_" + Guid.NewGuid().ToString().Substring(0, 4) + Path.GetExtension(myfile.FileName);
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return Ok(new { dbPath });

            }
            return BadRequest();

        }



    }


    //[HttpGet("/user-photo/{id:string?}", Name = "user-photo")]
    //public async Task<IActionResult> UserPhoto(string id)
    //{
    //    var (Data, type, name) = await userService.GetPhoto(id);
    //    return File(Data, type, name);
    //}

}



