using Beetsoft_Management_System.Data;
using Beetsoft_Management_System.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Beetsoft_Management_System.Controllers
{
    public class PositionController : BaseController
    {
        private readonly ApplicationDbContext context;
        public PositionController(UserManager<User> userManager, ApplicationDbContext context) : base(userManager)
        {
            this.context = context;
        }

        public class CreatePosition
        {
            public string Name {set;get;}
        }

        public class ViewModel
        {
            public int Id {set;get;}

            public string Name {set;get;}
        }

        [HttpGet("Positions")]
        public async Task<IActionResult> Positions()
        {
            var result = await context.Postions.Select(p => new ViewModel {Id = p.Id, Name = p.PositionName}).ToListAsync();

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Position(CreatePosition model)
        {
            context.Postions.Add(new Position{
                PositionName = model.Name
            });
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("PositionId/{id}")]

        public async Task<IActionResult> PositionId(int id)
        {
             context.Postions.FirstOrDefault(p => p.Id.Equals(id));
           await context.SaveChangesAsync();
            return Ok();
        }
    }
}