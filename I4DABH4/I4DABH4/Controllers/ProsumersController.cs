using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using I4DABH4.Models;
using I4DABH4.Repos;

namespace I4DABH4.Controllers
{
    [Produces("application/json")]
    [Route("api/Prosumers")]
    public class ProsumersController : Controller
    {
        private readonly ProsumerRepository _prosumerRepository;

        public ProsumersController(ProsumerRepository repository)
        {
            _prosumerRepository = repository; 
        }

        // GET: api/Prosumers
        [HttpGet]
        public IEnumerable<Prosumer> GetProsumers()
        {
            return _prosumerRepository.GetAll();
        }

        // GET: api/Prosumers/5
        [HttpGet("{id}")]
        public IActionResult GetProsumer([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prosumer = _prosumerRepository.Get(id);

            if (prosumer == null)
            {
                return NotFound();
            }

            return Ok(prosumer);
        }

        // PUT: api/Prosumers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProsumer([FromRoute] long id, [FromBody] Prosumer prosumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prosumer.ProsumerId)
            {
                return BadRequest();
            }

            _prosumerRepository.Update(prosumer);
            try
            {
                
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

            _prosumerRepository.Insert(prosumer);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetProsumer", new { id = prosumer.Address }, prosumer);
        }

        // DELETE: api/Prosumers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProsumer([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prosumer = _prosumerRepository.Get(id);
            if (prosumer == null)
            {
                return NotFound();
            }

            _prosumerRepository.Delete(prosumer);
            //await _context.SaveChangesAsync();

            return Ok(prosumer);
        }

        private bool ProsumerExists(long id)
        {
            return _prosumerRepository.Get(id) != null; 
        }
    }
}