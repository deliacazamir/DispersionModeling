using System.Threading.Tasks;
using DispersionModeling.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DispersionModeling.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        // GET 
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var values = await _context.Users.ToListAsync();
            return Ok(values);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var value = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }
    }
}