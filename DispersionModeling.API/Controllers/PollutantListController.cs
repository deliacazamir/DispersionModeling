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
    public class PollutantListController : ControllerBase
    {
        private readonly DataContext _context;
        public PollutantListController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PollutantList>>> GetPollutantLists()
        {
            return await _context.PollutantLists.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PollutantList>> GetPollutantLists (int id)
        {
            var pollutantList = await _context.PollutantLists.FindAsync();

            if( pollutantList == null)
            {
                return NotFound();
            }

            return pollutantList;
        }

        [HttpPost]
        public async Task<ActionResult<PollutantList>> PostPollutantLists (PollutantList pollutantList)
        {
            _context.PollutantLists.Add(pollutantList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetForm", new { id = pollutantList.PollutantListID}, pollutantList);
        }


    }
}