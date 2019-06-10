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
    public class PollutantController : ControllerBase
    {
        private readonly DataContext _context;
        public PollutantController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pollutant>>> GetPollutants()
        {
            return await _context.Pollutants.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pollutant>> GetPollutant (int id)
        {
            var pollutantList = await _context.Pollutants.FindAsync();

            if( pollutantList == null)
            {
                return NotFound();
            }

            return pollutantList;
        }

        //Insert
        [HttpPost]
        public async Task<ActionResult<Pollutant>> PostPollutantList (Pollutant pollutantList)
        {
            _context.Pollutants.Add(pollutantList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPollutant", new { id = pollutantList.Id}, pollutantList);
            
        }


        //Delete
        [HttpPost("{id}")]
        public async void  PostPollutantList (int id)
        {
            Pollutant  pollutantList=  new Pollutant(){Id = id};

            _context.Entry(pollutantList).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();
            
        }

           /* Update
        [HttpPut("{id}")]
        public async Task<ActionResult<PollutantList>> PutPollutantList (int id,[FromBody]PollutantList pollutantList)
        {
            _context.Update(pollutantList);
            
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetPollutantList", new { id = pollutantList.PollutantListID}, pollutantList);
            
        }
        */

    }
}