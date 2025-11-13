using Microsoft.AspNetCore.Mvc;
using PROG7312.Models;

namespace PROG7312.Services
{
    public class RequestStatusService
    {
        //turning linked list into regular list to display all reports

        private static ReportLinkedList _reports = new ReportLinkedList();


        public RequestStatusService()
        {
           
        }

        public List<ReportNode> GetReports()  // 
        {
            var reports = new List<ReportNode>();
            var currentReport = _reports.Head;

            while (currentReport != null)
            {
                reports.Add(currentReport);
                currentReport = currentReport.Next;
            }

            return reports;
        }
    }
}
