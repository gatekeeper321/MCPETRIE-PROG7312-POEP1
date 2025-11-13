namespace PROG7312.Models
{
    public class TreeNode
    {
        public int ReportID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public IFormFile ReportImage { get; set; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }


        public TreeNode(int id, string firstName, string lastName, string category, string location, string description, string status, IFormFile reportImage)
        {
            ReportID = id;
            FirstName = firstName;
            LastName = lastName;
            Category = category;
            Location = location;
            Description = description;
            Status = status;
            ReportImage = reportImage;
            Left = null;
            Right = null;
        }
    }
}
