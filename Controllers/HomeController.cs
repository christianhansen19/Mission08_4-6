using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission08_4_6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_4_6.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTask()
        {
            return View("TaskApplication");
        }
    
        public IActionResult Quadrants()
        {
            return View();
        }

    }
}
