using Microsoft.AspNetCore.Mvc;
using PROG7312.Models;
using PROG7312.Services;
using PROG7312.ViewModels;

namespace PROG7312.Controllers
{
    public class ServiceRequestStatusController : Controller
    {
        private static RequestStatusService _requestStatusService;
        private static BinarySearchTree _binarySearchTree;
        private static Graph _gs = new Graph();

        public ServiceRequestStatusController(RequestStatusService requestStatusService, BinarySearchTree binarySearchTree) 
        {
            _requestStatusService = requestStatusService;
            _binarySearchTree = binarySearchTree;
        }

        public IActionResult ServiceRequestStatusSearch()
        {
            return View();
        }

        public IActionResult ServiceRequestStatusList()
        {
            var viewModel = new ServiceRequestViewModel
            {
                Reports = RuntimeData.GetReports()
            };

            return View(viewModel);
        }

        public IActionResult GetReport(int ReportID) 
        {
            var treeReport = RuntimeData.searchTree.GetNode(ReportID);  // using binary search tree to get report with report id
            
            var viewModel = new ServiceRequestViewModel { }; // creating empty viewmodel in case tree report or report = null. so viewmodel exists before returning it to view

            if (treeReport == null) 
            {
                return View("~/Views/ServiceRequestStatus/ServiceRequestStatusSearch.cshtml", viewModel);
            }

            var report = RuntimeData.GetReports().FirstOrDefault(r => r.ReportID == treeReport.ReportID); 

            if (report == null) 
            {
                return View("~/Views/ServiceRequestStatus/ServiceRequestStatusSearch.cshtml", viewModel);
            }

            //Console.WriteLine(ReportID);
            //Console.WriteLine(treeReport.ReportID);

            _gs = _gs.CreateGraph(report.Location, RuntimeData.GetReports()); // creating graph for this specifc location
            var dependencies = _gs.GetDependencies(report).Where(r => r.ReportID != report.ReportID).ToList(); //traversing graph to find all dependcies aka all reports that have to be completed before municpality moves on to searched report 

            viewModel.Dependencies = dependencies;
            viewModel.SearchedReport = report;

            return View("~/Views/ServiceRequestStatus/ServiceRequestStatusSearch.cshtml", viewModel);
        }



    }
}
