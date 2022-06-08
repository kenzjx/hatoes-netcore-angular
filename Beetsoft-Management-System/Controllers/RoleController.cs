using Beetsoft_Management_System.Systems;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Beetsoft_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // HTTP POST https://localhost:5001/api/role
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleCreateRequest request)
        {
            var role = new IdentityRole()
            {
                Id = request.Id,
                Name = request.Name,
                NormalizedName = request.Name.ToUpper()
            };

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Errors);
            }

        }

        // HTTP GET https://localhost:5001/api/role/roles
        [HttpGet("Roles")]
        public async Task<IActionResult> GetRoles(string searchString, int pageIndex, int pageSize)
        {
            var query = _roleManager.Roles;

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.Id.Contains(searchString) || x.Name.Contains(searchString));
            }

            var totalRecords = await query.CountAsync();

            var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize)
                                    .Select(x => new RoleViewModel()
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                    })
                                    .ToListAsync();

            var pagination = new Pagination<RoleViewModel>
            {
                Items = items,

                TotalRecords = totalRecords,
            };

            return Ok(pagination);
        }

        // HTTP POST https://localhost:5001/api/role/Roles/{id}
        [HttpGet("Roles/{id}")]
        public async Task<IActionResult> GetRoleById(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
                return NotFound();

            var roleVm = new RoleViewModel()
            {
                Id = role.Id,
                Name = role.Name,
            };

            return Ok(roleVm);
        }


        // HTTP PUT https://localhost:5001/api/role/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(string id, [FromBody] RoleCreateRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
                return NotFound();

            role.Name = request.Name;
            role.NormalizedName = request.Name.ToUpper();

            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest(result.Errors);
        }

        // HTTP DELETE https://localhost:5001/api/role/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
                return NotFound();

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                var roleVm = new RoleViewModel()
                {
                    Id = role.Id,
                    Name = role.Name,
                };

                return Ok(roleVm);
            }

            return BadRequest(result.Errors);
        }
    }
}
