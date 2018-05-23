using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using I4DABH4.Data.Traderinfo;
using I4DABH4.Dto;
using I4DABH4.Models;
using Microsoft.AspNetCore.Mvc;

namespace I4DABH4.Controllers
{
    [Produces("application/json")]
    [Route("api/GridInfo")]
    public class GridController : Controller
    {
        private readonly GridRepo _gridRepo;
        public GridController(IUnitOfWork gridRepo)
        {
            _gridRepo = gridRepo.GridRepo;
        }

        // GET: api/GridInfo
        [HttpGet]
        public IEnumerable<GridInfo> Get()
        {
            return _gridRepo.GetAll().AsEnumerable();
        }

        // GET: api/GetGridForId
        [HttpGet("GetAll/{GridId}")]
        public GridInfo Get(string gridId)
        {
            return _gridRepo.Get(gridId);
        }

        public void Put([FromBody]GridInfo model)
        {
            _gridRepo.Update(model);
        }

    }
}