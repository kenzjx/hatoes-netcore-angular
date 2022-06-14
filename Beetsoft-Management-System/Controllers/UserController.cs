using System.Net;
using Beetsoft_Management_System.Data;
using Beetsoft_Management_System.Data.Entities;
using Beetsoft_Management_System.Interface;
using Beetsoft_Management_System.Systems;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;

namespace Beetsoft_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _webHostEnviroment;

        public UserController(UserManager<User> userManager, ApplicationDbContext context, IWebHostEnvironment webHostEnviroment)
        {
            _userManager = userManager;
            _context = context;
            _webHostEnviroment = webHostEnviroment;
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

        [Route("UpdateAvartarUser/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateAvatar(string id, [FromForm] PhotoRequest request)
        {
            var user = await _userManager.FindByIdAsync(id);

            string imgUrl = string.Empty;

            if (request.MyFile != null)
            {
                var uniqueFileName = Path.GetFileNameWithoutExtension(request.MyFile.FileName) + "_" + Guid.NewGuid().ToString().Substring(0, 4) + Path.GetExtension(request.MyFile.FileName);
                var filePath = Path.Combine(_webHostEnviroment.WebRootPath, "Uploads/Images", uniqueFileName);
                await request.MyFile.CopyToAsync(new FileStream(filePath, FileMode.Create));
                imgUrl = $"Uploads/Images/{uniqueFileName}";
            }

            user.ImagePath = $"https://localhost:5001/{imgUrl}";

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest(result.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(string searchString, int pageIndex, int pageSize)
        {
            var query = _userManager.Users
                                     .Join(_context.Departments, u => u.DepartmentId, d => d.Id, (u, d) => new { u, d })
                                     .Join(_context.UserRoles, x => x.u.Id, ur => ur.UserId, (x, ur) => new { x, ur })
                                     .Join(_context.Roles, k => k.ur.RoleId, r => r.Id, (k, r) => new { k, r })
                                     .Select(user => new UserViewModel()
                                     {
                                         Email = user.k.x.u.Email,
                                         DisplayName = user.k.x.u.FirstName + user.k.x.u.LastName,
                                         StartDate = user.k.x.u.StartDate,
                                         EndDate = user.k.x.u.EndDate,
                                         Department = user.k.x.d.DepartmentName,
                                         Role = user.r.Name,
                                         Status = user.k.x.u.Status,
                                        //  Type = user.k.x.u.Type
                                     });

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.Email.Contains(searchString) || x.DisplayName.Contains(searchString));
            }

            var totalRecords = await query.CountAsync();

            var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            var pagination = new Pagination<UserViewModel>
            {
                Items = items,
                TotalRecords = totalRecords
            };

            return Ok(pagination);
        }



        // [HttpGet("/user-photo/{id}", Name = "user-photo")]
        // public async Task<IActionResult> UserPhoto(string? id)
        // {
        //     var (Data, type, name) = await userService.GetPhoto(id);
        //     return File(Data, type, name);
        // }
      



    }


    //[HttpGet("/user-photo/{id:string?}", Name = "user-photo")]
    //public async Task<IActionResult> UserPhoto(string id)
    //{
    //    var (Data, type, name) = await userService.GetPhoto(id);
    //    return File(Data, type, name);
    //}

}



