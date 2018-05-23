using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using I4DABH4.Data.Traderinfo;
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

 
    }
}