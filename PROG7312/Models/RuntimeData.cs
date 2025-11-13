using PROG7312.Services; 

namespace PROG7312.Models
{
    public static class RuntimeData
    {
        public static ReportLinkedList reportList = new ReportLinkedList(); //linked list to store data/nodes
        public static BinarySearchTree searchTree;

        static RuntimeData()
        {
            searchTree = new BinarySearchTree();

            if (reportList.Head == null) // sample data
            {
                reportList.Add(new ReportNode("John", "Doe", "Water", "Main Street", "Burst pipe", "Pending", null));
                reportList.Add(new ReportNode("Jane", "Smith", "Electricity", "Highway Rd", "Power outage", "Pending", null));
                reportList.Add(new ReportNode("William", "McPetrie", "Roads", "Fountain Avenue", "Potholes in road", "Complete", null));
                reportList.Add(new ReportNode("Marli", "Naomi", "Sanitation", "Dashund St", "Overflowing sewage in rd", "Complete", null));
                reportList.Add(new ReportNode("Bart", "Williams", "Roads", "Talana Rd", "Street lights are not turning off during the day", "Complete", null));
                reportList.Add(new ReportNode("Henry", "Sorour", "Electricity", "Keurboom st", "Power outtage since 9am Nov 8th", "Pending", null));
                reportList.Add(new ReportNode("Edward", "Davids", "Electricity", "Fourth Rd", "Faulty power lines at the top of this street", "Complete", null));
                reportList.Add(new ReportNode("Michael", "Evans", "Other", "Computer Rd", "Lots of endangered baby birds in park", "Pending", null));
                reportList.Add(new ReportNode("Tom", "Witherspoon", "Sanitation", "Hout Bay Rd", "Sewage block in lower Hout Bay Rd", "Pending", null));
                reportList.Add(new ReportNode("Chris", "Evans", "Roads", "Movie Rd", "Major pot holes issue", "Complete", null));
                reportList.Add(new ReportNode("Reece", "Johnson", "Sanitation", "Fishhoek Rd", " Sewage block in lower Fishhoek Rd", "In Progress", null));
                reportList.Add(new ReportNode("Michael", "Michaelson", "Electricity", "Fishhoek Rd", " Street Lights Out", "Pending", null));
                reportList.Add(new ReportNode("Jack", "Mitchel", "Roads", "Fishhoek Rd", " Pot holes", "Pending", null));
                reportList.Add(new ReportNode("Daniel", "Smith", "Sanitation", "Loch Rd", " Sewage block in lower Fishhoek Rd", "Pending", null));
                reportList.Add(new ReportNode("Annelize", "Bester", "Other", "Loch Rd", "Continuous noise complaint", "Pending", null));
                reportList.Add(new ReportNode("Henry", "Alan", "Electricity", "Loch Rd", " Street Lights Out", "Pending", null));
            }

            //Adding first node in BST. it is using node roughly in middle of reportlist to make tree more effective
            var middleNode = reportList.Head.Next.Next.Next.Next.Next;
            var treeNode1 = new TreeNode(
                    middleNode.ReportID,
                    middleNode.FirstName,
                    middleNode.LastName,
                    middleNode.Category,
                    middleNode.Location,
                    middleNode.Description,
                    middleNode.Status,
                    middleNode.ReportImage
            );

            searchTree.Insert(treeNode1);

            var currentNode = reportList.Head;
            while (currentNode != null) // filling rest of reportlist into tree
            {
                if (currentNode != middleNode) //makes sure not to try add middle node again
                {
                    var treeNode = new TreeNode(
                    currentNode.ReportID,
                    currentNode.FirstName,
                    currentNode.LastName,
                    currentNode.Category,
                    currentNode.Location,
                    currentNode.Description,
                    currentNode.Status,
                    currentNode.ReportImage
                );

                    //Console.WriteLine("hello");
                    searchTree.Insert(treeNode);
                }

                currentNode = currentNode.Next;
            }
        }

        public static List<ReportNode> GetReports()
        {
            var reports = new List<ReportNode>();
            var currentReport = reportList.Head;

            while (currentReport != null)
            {
                reports.Add(currentReport);
                currentReport = currentReport.Next;
            }

            return reports;
        }


    }
}
