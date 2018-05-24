using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using I4DABH4.Data.Prosumerinfo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using I4DABH4.Models;

namespace I4DABH4.Controllers
{
    [Produces("application/json")]
    [Route("api/GridSettings")]
    public class GridSettingsController : Controller
    {
        private readonly IUnitOfWork _uow;

        public GridSettingsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/GridSettings
        [HttpGet]
        public GridSettings GetGridSetting()
        {
            return _uow.GridRepo.GetAll().FirstOrDefault();
        }

        // POST: api/GridSettings
        [HttpPost]
        public IActionResult PostGridSettings([FromBody] GridSettings gridSettings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _uow.GridRepo.SetGridSettings(gridSettings);
            _uow.SaveChanges();

            return Ok(gridSettings);
        }

    }
}