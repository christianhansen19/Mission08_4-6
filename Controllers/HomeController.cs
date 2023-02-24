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

        // Edit - Get
        [HttpGet]
        public IActionResult Edit(int TaskID)
        {
            ViewBag.Quadrants = tfContext.Quadrants.ToList();

            var task = tfContext.Responses.Single(x => x.TaskID == TaskID);

            return View("TaskApplication", task);
        }

        // Edit - Post
        [HttpPost]
        public IActionResult Edit(FormResponse fr, int taskid)
        {
            if (ModelState.IsValid)
            {
                tfContext.Update(fr);
                tfContext.SaveChanges();

                return RedirectToAction("Quadrants", fr);
            }
            else
            {
                ViewBag.Quadrants = tfContext.Quadrants.ToList();
                var task = tfContext.Responses.Single(data => data.TaskID == taskid);

                return View("TaskApplication", task);
            }
        }

        [HttpGet]
        public IActionResult Delete(int TaskID)
        {
            var task = tfContext.Responses.Single(x => x.TaskID == TaskID);

            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(FormResponse fr)
        {
            tfContext.Responses.Remove(fr);
            tfContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }

    }
}
