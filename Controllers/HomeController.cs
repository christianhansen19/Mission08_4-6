using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //Constructor
        public HomeController()
        {
            //leave for now
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
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
