using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PROG7312.Services
{
    public class EAService
    {
        public Dictionary<string, Event> Events { get; set; } = new Dictionary<string, Event>();
        public Stack<string> RecentlyViewed { get; set; } = new Stack<string>(); // stack to store recently viewed events
        HashSet<string> Categories = new HashSet<string>(); // hashset to store categories of events
        HashSet<DateTime> Dates = new HashSet<DateTime>(); // hashset to store dates of events

        public Dictionary<string, Announcement> Announcements { get; set; } = new Dictionary<string, Announcement>();
        public PriorityQueue<Announcement, int> AnnQueue { get; set; } = new PriorityQueue<Announcement, int>(); // priority queue to sort announcements using their priority so higher priority announcements will be shown first to users (not used but i have left it in just in case i want to use it in part 3)


        public class Announcement
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public string Location { get; set; }
            public string Description { get; set; }
            public string Author { get; set; }
            public int Priority { get; set; }

        }

        public class Event
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public string Location { get; set; }
            public string Category { get; set; }
            public string Description { get; set; }
            public double AdmissionFee { get; set; }
            public string Author { get; set; }
        }

        public EAService()
        {
            //sample data

            Events.Add("E00001", new Event { Id = "E00001", Name = "Claremont LAN", Date = new DateTime(2025, 10, 15, 20, 00, 00), Location = "Office B21, Claremont Warehouse", Category = "Gaming", Description = "Come and enjoy a LAN filled with locals for only R300 per person. Play any game with a friends or a bunch of like-minded people you meet at the event", AdmissionFee = 300.00, Author = "Will Mcpetrie"});
            Events.Add("E00002", new Event { Id = "E00002", Name = "SPCA Fund-raiser", Date = new DateTime(2025, 10, 29, 9, 30, 00), Location = "Greenpoint Promenade", Category = "Charity", Description = "The SPCA will be hosting a Fund-raiser event on the Greenpoint Promenade to raise funds for the care and housing of many shelter animals. The SPCA will be bringing dogs that will also be up for adoption if anyone will be interested. There will be no admission fee however they do request that both attendees and those not attending find it in their hearts to help their cause by iether donating funds or adopting an animal in need (or both)!", AdmissionFee = 0, Author = "President of SPCA" });
            Events.Add("E00003", new Event { Id = "E00003", Name = "Taylor Swift Concert", Date = new DateTime(2025, 12, 23, 20, 30, 00), Location = "Green Point Stadium", Category = "Concert", Description = "Taylor Swift will be performing a christmas-eve-eve concert in the Greenpoint Stadium, those who wish to join may purchase tickets at 'www.computicket.com/TaylorSwift/CapeTownStadium.' ", AdmissionFee = 3500.00, Author = "TS management team" });
            Events.Add("E00004", new Event { Id = "E00004", Name = "Formula E", Date = new DateTime(2027, 1, 8, 12, 45, 00), Location = "", Category = "Racing", Description = "Placeholder for info", AdmissionFee = 1100, Author = "Author" });
            Events.Add("E00005", new Event { Id = "E00005", Name = "Billie Eilish Concert", Date = new DateTime(2026, 3, 16, 18, 30, 00), Location = "Green Point Stadium", Category = "Concert", Description = "Placeholder for info", AdmissionFee = 2000, Author = "Author" });
            Events.Add("E00006", new Event { Id = "E00006", Name = "Two Oceans Marathon", Date = new DateTime(2025, 12, 1, 8, 30, 00), Location = "Green Point", Category = "Outdoors", Description = "Placeholder for info", AdmissionFee = 200, Author = "Author" });
            Events.Add("E00007", new Event { Id = "E00007", Name = "Cold Play Concert", Date = new DateTime(2026, 1, 12, 16, 00, 00), Location = "Green Point Stadium", Category = "Concert", Description = "Placeholder for info", AdmissionFee = 1500, Author = "Author" });
            Events.Add("E00008", new Event { Id = "E00008", Name = "Block House Hike", Date = new DateTime(2025, 11, 9, 10, 15, 00), Location = "Rhoades Memorial, Table Mountain", Category = "Outdoors", Description = "Placeholder for info", AdmissionFee = 0, Author = "Author" });
            Events.Add("E00009", new Event { Id = "E00009", Name = "CBD LAN", Date = new DateTime(2025, 12, 22, 14, 00, 00), Location = "Floor 6, FNB building", Category = "Gaming", Description = "Placeholder for info", AdmissionFee = 350, Author = "Author" });
            Events.Add("E00010", new Event { Id = "E00010", Name = "Park Run", Date = new DateTime(2025, 10, 17, 17, 30, 00), Location = "Rondebosch Common", Category = "Outdoors", Description = "Placeholder for info", AdmissionFee = 0, Author = "Author" });
            Events.Add("E00011", new Event { Id = "E00011", Name = "OscarsArc Fund-Raiser", Date = new DateTime(2025, 11, 15, 15, 00, 00), Location = "V&A Waterfront", Category = "Charity", Description = "Placeholder for info", AdmissionFee = 0, Author = "Author" });
            Events.Add("E00012", new Event { Id = "E00012", Name = "Cape Town Jazz Festival", Date = new DateTime(2026, 2, 17, 18, 30, 00), Location = "Green Point Stadium", Category = "Concert", Description = "Placeholder for info", AdmissionFee = 300, Author = "Author" });

            Announcements.Add("A00001", new Announcement { Id = "A00001", Name = "Two Oceans Marathon Road Closure", Date = new DateTime(2025, 11, 25, 9, 30, 00), Location = "Helen Suezman Boulevard", Description = "The Two Oceans Marathon will be taking place on November 25th, so please expect road closures throughout Cape Town. Particularly Helen Suezman Boulevard", Author = "Director of CTTD", Priority = 3 });
            Announcements.Add("A00002", new Announcement { Id = "A00002", Name = "Protesting", Date = new DateTime(2025, 11, 2, 9, 00, 00), Location = "Throughout Cape Town CBD", Description = "We have been informed of a string of peaceful protests that will occur through the Cape Town CBD on November 2nd. Please remember this for your travels as several loads may close due to this.", Author = "Mayor Geordan Hill-Lewis", Priority = 4 });

            ///////////////////////////////////////////////////////////////////////

            Categories.Add("Gaming");
            Categories.Add("Charity");
            Categories.Add("Concert");
            Categories.Add("Racing");
            Categories.Add("Outdoors");

            Dates.Add(new DateTime(2025, 10, 15).Date);
            Dates.Add(new DateTime(2025, 10, 29).Date);
            Dates.Add(new DateTime(2025, 12, 23).Date);
            Dates.Add(new DateTime(2027, 1, 8).Date);
            Dates.Add(new DateTime(2026, 3, 16).Date);
            Dates.Add(new DateTime(2025, 12, 1).Date);
            Dates.Add(new DateTime(2026, 1, 12).Date);
            Dates.Add(new DateTime(2025, 11, 9).Date);
            Dates.Add(new DateTime(2025, 12, 22).Date);
            Dates.Add(new DateTime(2025, 10, 17).Date);
            Dates.Add(new DateTime(2025, 11, 15).Date);
            Dates.Add(new DateTime(2026, 2, 17).Date);

            AnnQueue.Enqueue(Announcements["A00001"], Announcements["A00001"].Priority);
            AnnQueue.Enqueue(Announcements["A00002"], Announcements["A00002"].Priority);
        }

        public List<Event> CategorySearch(string searched)
        {
            if (Categories.Contains(searched))
            {
                return (Events.Values.Where(e => e.Category == searched).ToList());
            }
            else
            {
                return new List<Event>();
            }
        }

        public List<Event> DateSearch(string searched)
        {
            var dateOnly = DateTime.Parse(searched).Date; //converting to date only as its impractical to search by exact time as well

            if (Dates.Contains(dateOnly))
            {
                return (Events.Values.Where(e => e.Date.Date == dateOnly).ToList()); // DateTime is also made into date only for comparison to string searched
            }
            else
            {
                return new List<Event>();
            }
        }



    }
}
