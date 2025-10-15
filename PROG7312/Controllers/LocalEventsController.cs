using Microsoft.AspNetCore.Mvc;
using PROG7312.Models;
using System.Diagnostics;
using PROG7312.Services;

namespace PROG7312.Controllers
{
    public class LocalEventsController : Controller
    {
        private readonly ILogger<LocalEventsController> _logger;

        public LocalEventsController(ILogger<LocalEventsController> logger)
        {
            _logger = logger;
        }

        public IActionResult LocalEventsAndAnnouncements()
        {
            return View();
        }

        public IActionResult CreateEvent()
        {
            return View();
        }

        public IActionResult CreateAnnouncement()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult AddEvent(string name, DateTime date, string location, string description, double admissionFee, string author) 
        {
            //add logic
            return View("LocalEventsAndAnnouncements");
        }

        public IActionResult AddAnnouncement(string name, DateTime date, string location, string description, string author)
        {
            //add logic
            return View("LocalEventsAndAnnouncements");
        }
    }
}

