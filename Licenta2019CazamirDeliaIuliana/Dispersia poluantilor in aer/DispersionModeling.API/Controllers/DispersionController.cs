using System.Collections.Generic;
using System.Threading.Tasks;
using DispersionModeling.API.Data;
using DispersionModeling.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DispersionModeling.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DispersionController : ControllerBase
    {
             private readonly DataContext _context;
        public DispersionController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DispersionModel>>> GetDispersionModels()
        {
            return await _context.DispersionModels.ToListAsync();
        }



        [HttpGet("{id}")]
         public async Task<ActionResult<IEnumerable<DispersionModel>>> GetDispersionModel (int id) 
         {
            var userDispersionModel = await _context.DispersionModels.FromSql("select * from DispersionModels join UserDispersionModels on DispersionModels.Id = UserDispersionModels.DispersionModelID where UserDispersionModels.UserID ="+id).ToListAsync();
            if(userDispersionModel == null)
            {
                 return NotFound();
            }
            
            return userDispersionModel;
        }

        //Insert
        [HttpPost]
        public async Task<ActionResult> PostDispersionModel (DispersionModel dispersionModel)
        {
            _context.DispersionModels.Add(dispersionModel);
            await _context.SaveChangesAsync();
            
            
            return CreatedAtAction("GetDispersionModel", new { id = dispersionModel.Id}, dispersionModel);
            
        }

    }
    
}

