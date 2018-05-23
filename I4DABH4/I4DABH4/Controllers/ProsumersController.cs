using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using I4DABH4.Data.Traderinfo;
using I4DABH4.Dto;
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
        private IUnitOfWork _uow;

        public ProsumersController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Prosumers
        [HttpGet]
        public IEnumerable<Prosumer> GetProsumers()
        {
            return _uow.ProsumerRepo.GetAll();
        }

        // GET: api/Prosumers/5
        [HttpGet("{id}")]
        public IActionResult GetProsumer([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var prosumer = _uow.ProsumerRepo.Get(id);
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
            _uow.ProsumerRepo.Update(prosumer);

            try
            {
                _uow.SaveChanges();
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
        public IActionResult PostProsumer([FromBody] ProsumerDTO prosumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toadd = new Prosumer()
            {
                Type = prosumer.Type,
                NetValue = prosumer.NetValue,
                Address = prosumer.Address
            };
            _uow.ProsumerRepo.Insert(toadd);
            _uow.SaveChanges();

            return CreatedAtAction("GetProsumer", new { id = toadd.ProsumerId}, toadd);
        }

        // DELETE: api/Prosumers/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProsumer([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prosumer = _uow.ProsumerRepo.Get(id);
            if (prosumer == null)
            {
                return NotFound();
            }

            _uow.ProsumerRepo.Delete(prosumer);
            _uow.SaveChanges();

            return Ok(prosumer);
        }

        private bool ProsumerExists(long id)
        {
            return _uow.ProsumerRepo.Get(id) != null;
        }
    }
}