using Microsoft.AspNetCore.Mvc;
using Bazar.API.Data;
using Bazar.API.Models;

namespace Bazar.API.Controllers
{
    [ApiController]

    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly BazarDbContext _context;

        public UserController(BazarDbContext context) {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();

            return Ok(users);

        }
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);

        }
    }
}
        

