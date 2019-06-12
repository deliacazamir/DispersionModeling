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
    public class StationTypePollutantController: ControllerBase
    {
        private readonly DataContext _context;
        public StationTypePollutantController(DataContext context)
        {
            _context = context;
        }

        // GET : api/StationTypePollutant               
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationTypePollutant>>> GetStationTypePollutants () 
        {
            return await _context.StationTypePollutants.ToListAsync();
        }

         [HttpGet("{id}")]
         public async Task<ActionResult<IEnumerable<Pollutant>>> GetStationTypePollutant (int id) 
         {
             //var stationType = await _context.StationTypePollutants.FromSql("select * from StationTypePollutants where StationTypeID="+id).ToListAsync();

            var stationType = await _context.Pollutants.FromSql("select * from Pollutants LEFT JOIN StationTypePollutants  ON Pollutants.Id = StationTypePollutants.PollutantID where StationTypePollutants.StationTypeID ="+id).ToListAsync();
            if(stationType == null)
            {
                 return NotFound();
            }
            
            return stationType;
        }

    }
}