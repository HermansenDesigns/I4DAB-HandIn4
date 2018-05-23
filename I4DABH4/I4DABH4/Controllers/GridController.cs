using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace I4DABH4.Controllers
{
    public class GridController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}