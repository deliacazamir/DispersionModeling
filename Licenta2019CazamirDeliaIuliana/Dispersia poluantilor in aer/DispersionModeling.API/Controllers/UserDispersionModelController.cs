using System.Collections.Generic;
using System.Threading.Tasks;
using DispersionModeling.API.Data;
using DispersionModeling.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DispersionModeling.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDispersionModelController : ControllerBase
    {
        private readonly DataContext _context;
        public UserDispersionModelController(DataContext context)
        {
            _context = context;
        }
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDispersionModel>>> GetUserDispersionModels()
        {
            return await _context.UserDispersionModels.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<UserDispersionModel>> PostUserDispersionModels (UserDispersionModel userDispersionModel)
        {
            _context.UserDispersionModels.Add(userDispersionModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDispersionModels", new { userDispersionModel} );
            
        }

        [HttpGet("{id}")]
         public async Task<ActionResult<IEnumerable<DispersionModel>>> GetUserDispersionModel (int id) 
         {
            var userDispersionModel = await _context.DispersionModels.FromSql("select * from DispersionModels join UserDispersionModels on DispersionModels.Id = UserDispersionModels.DispersionModelID where UserDispersionModels.UserID ="+id).ToListAsync();
            if(userDispersionModel == null)
            {
                 return NotFound();
            }
            
            return userDispersionModel;
        }
    }
}