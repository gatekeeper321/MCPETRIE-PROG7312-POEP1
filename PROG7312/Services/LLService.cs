using Microsoft.AspNetCore.Mvc;

namespace PROG7312.Services
{
    public class ReportNode
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public IFormFile ReportImage { get; set; }
        public ReportNode Next { get; set; }

        public ReportNode(string firstName, string lastName, string category, string location, string description, IFormFile reportImage)
        {
            FirstName = firstName;
            LastName = lastName;
            Category = category;
            Location = location;
            Description = description;
            ReportImage = reportImage;
            Next = null;
        }
    }

    public class ReportLinkedList
    {
        public ReportNode Head { get; set; }
        public ReportNode Tail { get; set; }
        public ReportLinkedList()
        {
            Head = null;
            Tail = null;
        }

        public void Add(ReportNode newNode)
        {
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }

            Console.WriteLine("New report added: " + newNode.FirstName + " " + newNode.LastName + " " + newNode.Category + " " + newNode.Location + " " + newNode.Description);
        }
    }
}
