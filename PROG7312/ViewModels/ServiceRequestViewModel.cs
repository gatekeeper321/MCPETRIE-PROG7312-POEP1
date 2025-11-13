using PROG7312.Models;
using PROG7312.Services;
using System.Collections.Generic;

namespace PROG7312.ViewModels
{
    public class ServiceRequestViewModel
    {
        public List<ReportNode> Reports { get; set; } = new();

        public ServiceRequestViewModel()
        {
            Reports = new List<ReportNode>();
        }

        public ReportNode SearchedReport { get; set; }

        public List<ReportNode> Dependencies { get; set; } = new();
    }
}
