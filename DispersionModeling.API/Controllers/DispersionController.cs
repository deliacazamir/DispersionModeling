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
        public async Task<ActionResult<DispersionModel>> GetDispersionModel (int id)
        {
            var dispersionModel = await _context.DispersionModels.FindAsync();

            if( dispersionModel == null)
            {
                return NotFound();
            }

            return dispersionModel;
        }

        //Insert
        [HttpPost]
        public async Task<ActionResult<DispersionModel>> PostDispersionModel (DispersionModel dispersionModel)
        {
            _context.DispersionModels.Add(dispersionModel);
            await _context.SaveChangesAsync();
            

            // GPSLocation gpslocation = new GPSLocation();

            // string [] gpslocationVector ;
            // for(int i=0;i<20;i++)
            // for(int j=0;j<20;j++)

            // _context.GPSLocations.Add(gpslocation);
            // await _context.SaveChangesAsync();

            return CreatedAtAction("GetDispersionModel", new { id = dispersionModel.Id}, dispersionModel);
            
        }

    }
    
}