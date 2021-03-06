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

    public class PollutionSourceController : ControllerBase
    {
        private readonly DataContext _context;
        public PollutionSourceController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PollutionSource>>> GetPollutionSources()
        {
            return await _context.PollutionSources.ToListAsync();
        }

        //Insert
        [HttpPost]
        public async Task<ActionResult<PollutionSource>> PostPollutionSource (PollutionSource pollutionSource)
        {
            _context.PollutionSources.Add(pollutionSource);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPollutionSource", new { id = pollutionSource.Id}, pollutionSource);
            
        }

        [HttpGet("{id}")]
         public async Task<ActionResult<IEnumerable<PollutionSource>>> GetPollutionSource (int id) 
         {
            var pollutionSource = await _context.PollutionSources.FromSql("select * from PollutionSources where UserID ="+id).ToListAsync();
            if(pollutionSource == null)
            {
                 return NotFound();
            }
            
            return pollutionSource;
        }
    }
}