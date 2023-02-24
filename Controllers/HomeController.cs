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
        private TaskFormContext tfContext { get; set; }

        //Constructor
        public HomeController(TaskFormContext someName)
        {
            tfContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Quadrants = tfContext.Quadrants.ToList();
            return View("TaskApplication");
        }

        [HttpPost]
        public IActionResult AddTask(FormResponse fr)
        {
            if (ModelState.IsValid) // if the model is valid, display the confirmation page
            {
                tfContext.Add(fr);
                tfContext.SaveChanges();
                return View("Confirmation", fr);
            }
            else // if the model is invalid, display form page still
            {
                ViewBag.Quadrants = tfContext.Quadrants.ToList();
                return View("TaskApplication", fr);
            }

        }

        public IActionResult Quadrants()
        {
            var applications = tfContext.Responses
            .Include(x => x.Quadrant)
            .Where(x => x.Completed == false)
            .OrderBy(x => x.TaskID)
            .ToList();

            return View(applications);
        }

    }
}
