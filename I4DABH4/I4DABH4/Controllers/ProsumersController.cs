using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using I4DABH4.Models;

namespace I4DABH4.Controllers
{
    [Produces("application/json")]
    [Route("api/Prosumers")]
    public class ProsumersController : Controller
    {
        private readonly ProsumerContext _context;

        public ProsumersController(ProsumerContext context)
        {
            _context = context;
        }

        // GET: api/Prosumers
        [HttpGet]
        public IEnumerable<Prosumer> GetProsumers()
        {
            return _context.Prosumers;
        }

        // GET: api/Prosumers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProsumer([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prosumer = await _context.Prosumers.SingleOrDefaultAsync(m => m.Address == id);

            if (prosumer == null)
            {
                return NotFound();
            }

            return Ok(prosumer);
        }

        // PUT: api/Prosumers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProsumer([FromRoute] string id, [FromBody] Prosumer prosumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prosumer.Address)
            {
                return BadRequest();
            }

            _context.Entry(prosumer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProsumerExists(id))
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

        // POST: api/Prosumers
        [HttpPost]
        public async Task<IActionResult> PostProsumer([FromBody] Prosumer prosumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Prosumers.Add(prosumer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProsumer", new { id = prosumer.Address }, prosumer);
        }

        // DELETE: api/Prosumers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProsumer([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prosumer = await _context.Prosumers.SingleOrDefaultAsync(m => m.Address == id);
            if (prosumer == null)
            {
                return NotFound();
            }

            _context.Prosumers.Remove(prosumer);
            await _context.SaveChangesAsync();

            return Ok(prosumer);
        }

        private bool ProsumerExists(string id)
        {
            return _context.Prosumers.Any(e => e.Address == id);
        }
    }
}