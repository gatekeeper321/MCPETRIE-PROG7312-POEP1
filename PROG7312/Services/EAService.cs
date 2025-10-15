using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PROG7312.Services
{
    public class EAService
    {
        public Dictionary<string, Event> Events { get; set; } = new Dictionary<string, Event>();
        public Dictionary<string, Announcement> Announcements { get; set; } = new Dictionary<string, Announcement>();

        public class Announcement
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public string Location { get; set; }
            public string Description { get; set; }
            public string Author { get; set; }

        }

        public class Event
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public string Location { get; set; }
            public string Description { get; set; }
            public double AdmissionFee { get; set; }
            public string Author { get; set; }
        }

        public EAService()
        {
            Events.Add("E00001", new Event {Name = "LAN", Date = new DateTime(2025, 10, 15, 20, 00, 00), Location = "Office B21, Claremont Warehouse", Description = "Come and enjoy a LAN filled with locals for only R300 per person. Play any game with a friends or a bunch of like-minded people you meet at the event", AdmissionFee = 300.00, Author = "Will Mcpetrie"});
            Events.Add("E00002", new Event {Name = "SPCA Fund-raiser", Date = new DateTime(2025, 10, 29, 9, 30, 00), Location = "Greenpoint Promenade", Description = "The SPCA will be hosting a Fund-raiser event on the Greenpoint Promenade to raise funds for the care and housing of many shelter animals. The SPCA will be bringing dogs that will also be up for adoption if anyone will be interested. There will be no admission fee however they do request that both attendees and those not attending find it in their hearts to help their cause by iether donating funds or adopting an animal in need (or both)!", AdmissionFee = 0, Author = "President of SPCA" });
            Events.Add("E00003", new Event {Name = "Taylor Swift Concert", Date = new DateTime(2025, 12, 23, 20, 30, 00), Location = "Office B21, Claremont Warehouse", Description = "Taylor Swift will be performing a christmas-eve-eve concert in the Greenpoint Stadium, those who wish to join may purchase tickets at 'www.computicket.com/TaylorSwift/CapeTownStadium.' ", AdmissionFee = 3500.00, Author = "TS management team" });

            Announcements.Add("A00001", new Announcement {Name = "Two Oceans Marathon Road Closure", Date = new DateTime(2025, 11, 25, 9, 30, 00), Location = "Helen Suezman Boulevard", Description = "The Two Oceans Marathon will be taking place on November 25th, so please expect road closures throughout Cape Town. Particularly Helen Suezman Boulevard", Author = "Director of CTTD" });
        }

        public void AddEvent(string name, DateTime date, string location, string description, double admissionFee, string author) 
        {
            Events.Add("", new Event { Name = name, Date = date, Location = location, Description = description, AdmissionFee = admissionFee, Author = author });
        }

        public void AddAnnouncement(string name, DateTime date, string location, string description, string author) 
        {
            Announcements.Add("", new Announcement { Name = name, Date = date, Location = location, Description = description, Author = author });
        }
    }
}
