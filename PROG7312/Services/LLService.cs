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
        public ReportNode Next { get; set; } // Next points to the next node in the list, allowing for the lists to be linked together via nodes instead of with indexes

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
        public ReportLinkedList() //constructor to initialize empty linked list
        {
            Head = null;
            Tail = null;
        }

        public void Add(ReportNode newNode) //adding a node to the linked list
        {
            if (Head == null) //checking if list is empty
            {
                Head = newNode; 
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode; //linking the new node to end of list
                Tail = newNode; //making the new node the tail
            }

            Console.WriteLine("New report added: " + newNode.FirstName + " " + newNode.LastName + " " + newNode.Category + " " + newNode.Location + " " + newNode.Description); //console msg to verify data has been added to linked list
        }
    }
}
