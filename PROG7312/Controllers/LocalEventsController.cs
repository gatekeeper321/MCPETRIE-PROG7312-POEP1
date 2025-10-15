using Microsoft.AspNetCore.Mvc;
using PROG7312.Models;
using System.Diagnostics;
using static PROG7312.Services.EAService;
using PROG7312.Services;
using AspNetCoreGeneratedDocument;

namespace PROG7312.Controllers
{
    public class LocalEventsController : Controller
    {
        private readonly ILogger<LocalEventsController> _logger;
        private readonly EAService _eaService;

        public LocalEventsController(ILogger<LocalEventsController> logger, EAService eaService)
        {
            _logger = logger;
            _eaService = eaService;
        }

        public IActionResult LocalEventsAndAnnouncements()
        {
            return View(_eaService);
        }

        public IActionResult EventView(string Id)
        {
            Event e = _eaService.Events[Id];

            _eaService.RecentlyViewed.Push(Id); //Adding most recently viewed event which would be id, to the stack, so i can create a recently viewed section

            return View(e);
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

