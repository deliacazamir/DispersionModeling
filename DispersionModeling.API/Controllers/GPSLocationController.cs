using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DispersionModeling.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DispersionModeling.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GPSLocationController : ControllerBase
    {
        private readonly DataContext _context;
        public GPSLocationController(DataContext context)
        {
            _context = context;
        }

        // GET api/GPS or api/GPSLocation
        [HttpGet]
        public async Task<IActionResult> GetGPSLocations()
        {
            var values = await _context.GPSLocations.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGPSLocation(int id)
        {
            var value = await _context.GPSLocations.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }

        // [HttpPost]
        // [HttpPut]
        // [HttpDelete]
    }
}