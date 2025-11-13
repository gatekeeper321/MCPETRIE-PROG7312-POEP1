using PROG7312.Services;

namespace PROG7312.Services
{
    public class Graph
    {
        private Dictionary<ReportNode, List<ReportNode>> AdjecencyList { get; set; } 

        public Graph()
        {
            AdjecencyList = new Dictionary<ReportNode, List<ReportNode>>();
        }

        public Graph CreateGraph(string Location, List<ReportNode> reportList)
        {
            // gets list of reports and filters by location. Also orders by sanitation
            var locationReports = reportList.Where(r => r.Location == Location).OrderBy(r => Array.IndexOf(new[] { "Sanitation", "Electricity", "Roads", "Other" }, r.Category)).ToList();

            Graph graph = new Graph();

            // adding filtered locationreports as nodes
            for (int i = 0; i < locationReports.Count; i++)
            {
                graph.AddNode(locationReports[i]);
            }

            // creating edges based on adjacent priority. this is reversed as we want what the node relies on to be completed before it is daelt with by municipality
            for (int i = 0; i < locationReports.Count - 1; i++)
            {
                graph.AddEdge(locationReports[i + 1], locationReports[i]);
            }

            return graph;
        }

        public void AddNode(ReportNode node)
        {
            if (!AdjecencyList.ContainsKey(node))
            {
                AdjecencyList[node] = new List<ReportNode>(); // adding the node to the dictionary with empty dependencey list
            }
        }

        public void AddEdge(ReportNode dependency, ReportNode dependant) 
        {
            if (!AdjecencyList.ContainsKey(dependency)) // adding dependencey node if its  not already in dictionary
            {
                AddNode(dependency);
            }

            if (!AdjecencyList.ContainsKey(dependant)) // adding dependant node if its not already in dictionary
            {
                AddNode(dependant);
            }

            AdjecencyList[dependency].Add(dependant);
        }

        // Traversal of the above graph with depth first search
        public List<ReportNode> GetDependencies(ReportNode start) 
        {
            var list = new List<ReportNode>();
            // hash set not used as my graph is linear and does not create loop

            void Search(ReportNode node) 
            {
                list.Add(node); // adding node to list of depencies

                if (AdjecencyList.ContainsKey(node))
                {
                    foreach (var neighbour in AdjecencyList[node]) 
                    {
                        Search(neighbour); // reiterate through neighbours
                    }
                }
            }

            Search(start);
            return list;
        }

    }
}
