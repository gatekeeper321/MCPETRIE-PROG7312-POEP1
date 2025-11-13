using Microsoft.AspNetCore.Mvc;
using PROG7312.Models;
using System.Diagnostics;
using PROG7312.Services;

namespace PROG7312.Controllers
{
    public class ReportIssuesController : Controller
    {
        private readonly ILogger<ReportIssuesController> _logger;
        

        public ReportIssuesController(ILogger<ReportIssuesController> logger)
        {
            _logger = logger;
        }

        public IActionResult ReportIssues()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SubmitReport(string FirstName, string LastName, string Category, string Location, string Description, string Status, IFormFile reportImage) 
        {
            ReportNode newReport = new ReportNode(FirstName, LastName, Category, Location, Description, Status, reportImage); //creaeting new node with inputed data
            //reportField.Add(newReport); //adding the node to linked list

            RuntimeData.reportList.Add(newReport);

            return View("ReportIssues"); //return back to report issue page
        }
    }
}
