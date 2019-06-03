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
    public class FormController : ControllerBase
    {
        private readonly DataContext _context;
        public FormController(DataContext context)
        {
            _context = context;
        }

        //GET: api/Form
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Form>>> GetForms () {
            return await _context.Forms.ToListAsync();
        } 

        // [HttpGet]
        // public async Task<IActionResult> GetForms()
        // {
        //     var values = await _context.Forms.ToListAsync();
        //     return Ok(values);
        // }

        [HttpGet("{id}")]
        public async Task<ActionResult<Form>> GetForm (int id)
        {
            var form = await _context.Forms.FindAsync();

            if( form == null)
            {
                return NotFound();
            }

            return form;
        }

        [HttpPost]
        public async Task<ActionResult<Form>> PostForm (Form form)
        {
            _context.Forms.Add(form);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetForm", new { id = form.Id}, form);
        }

    }
}