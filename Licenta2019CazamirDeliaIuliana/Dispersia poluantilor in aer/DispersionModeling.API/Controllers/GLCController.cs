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

    public class GLCController : ControllerBase
    {
        private readonly DataContext _context;
        public GLCController(DataContext context)
        {
            _context = context;
        }

        //un post in care vin datele din front si le dau la algoritm

        //Insert
        [HttpGet]
        public async Task<ActionResult> GetGLC( )
        {
            // GPSLocation gpslocation = new GPSLocation();

            // string [] gpslocationVector ;
            // for(int i=0;i<20;i++)
            // for(int j=0;j<20;j++)
  ///var userDispersionModel = await _context.DispersionModels.FromSql("select * from DispersionModels join UserDispersionModels on DispersionModels.Id = UserDispersionModels.DispersionModelID where UserDispersionModels.UserID ="+id).ToListAsync();
     //       if(userDispersionModel == null)
       //     {
         //        return NotFound();
           // }
            // _context.GPSLocations.Add(gpslocation);
            // await _context.SaveChangesAsync();

            MyResult [] content = new MyResult[5] {new MyResult(1.2,32.23,1.0),
                                                    new MyResult(6.32,32.23,1.0),
                                                    new MyResult(6.2,432.23,15.0),
                                                    new MyResult(4.2,232.23,13.0),
                                                    new MyResult(-1.2,32.23,1.0)
                                                   };
         
            var result = JsonConvert.SerializeObject(content);
            
            return Ok(result);
            //return CreatedAtAction("GetDispersionModel", new { id = dispersionModel.Id}, dispersionModel);
            
        }

    }
    

public class MyResult {
    public  double lat = 1.0;
    public double longt = 1.0;
    public double concentration = 0.0;

    public MyResult(double lat, double longt, double concentration)
    {
        this.lat = lat;
        this.longt = longt;
        this.concentration = concentration;
    }
}

}