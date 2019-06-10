using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DispersionModeling.API.Data;
using DispersionModeling.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DispersionModeling.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationTypeController : ControllerBase
    {
        private readonly DataContext _context;
        public StationTypeController(DataContext context)
        {
            _context = context;
        }

        // GET : api/StationType                       READ
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationType>>> GetStationTypes () 
        {
            return await _context.StationTypes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StationType>> GetStationType (int id) 
        {
            var stationType = await _context.StationTypes.FindAsync(id);
            if(stationType == null)
            {
                return NotFound();
            }
            
            return stationType;
        }

        // PUT: api/StationType/id                     UPDATE
        [HttpPut("{id}")]               
        public async Task<IActionResult> PutStationType (int id, StationType stationType)
        {
            if( id != stationType.Id)
            {
                return BadRequest();
            }

            _context.Entry(stationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                ///not sure about if statement
                if(! StationTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        //POST api/StationType                      CREATE
        [HttpPost]
        public async Task<ActionResult<StationType>> PostStationType (StationType stationType)
        {
            _context.StationTypes.Add(stationType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStationType", new { id = stationType.Id}, stationType);
        }

        //DELETE api/StationType/id                   DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<StationType>> DeleteStationType (int id)
        {
            var stationType = await _context.StationTypes.FindAsync(id);
            if ( stationType == null )
            {
                return NotFound();
            }

            _context.StationTypes.Remove(stationType);
            await _context.SaveChangesAsync();

            return stationType;
        }

        private bool StationTypeExists (int id)
        {
            return _context.StationTypes.Any(x => x.Id == id);
        }
    }
}