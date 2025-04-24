using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Consent_Form.Data;
using Consent_Form.Model;

namespace Consent_Form.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class modelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public modelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/models
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models>>> GetModelTable()
        {
            return await _context.ModelTable.ToListAsync();
        }

        // GET: api/models/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getmodels(int id)
        {
            var model = await _context.ModelTable.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return Content(model.template, "text/plain");
        }


        // PUT: api/models/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmodels(int id, models models)
        {
            if (id != models.Id)
            {
                return BadRequest();
            }

            _context.Entry(models).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!modelsExists(id))
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

        // POST: api/models
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<models>> Postmodels(models models)
        {
            _context.ModelTable.Add(models);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmodels", new { id = models.Id }, models);
        }

        // DELETE: api/models/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemodels(int id)
        {
            var models = await _context.ModelTable.FindAsync(id);
            if (models == null)
            {
                return NotFound();
            }

            _context.ModelTable.Remove(models);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool modelsExists(int id)
        {
            return _context.ModelTable.Any(e => e.Id == id);
        }
    }
}
