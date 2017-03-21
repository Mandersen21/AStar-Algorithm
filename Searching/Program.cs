using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    class Program
    {
        static void Main(string[] args)
        {
            // A* search
            BuildStreetGraph streetGraph = new BuildStreetGraph();
            ShortestStreetPath shortestPath = new ShortestStreetPath();

            //// Search #1 (Start D: , Goal: F)
            //var searchProblem1 = streetGraph.MapStreetGraph();
            //shortestPath.search(searchProblem1[3], searchProblem1[5]);

            //// Search #2 (Start A: , Goal: M)
            //var searchProblem2 = streetGraph.MapStreetGraph();
            //shortestPath.search(searchProblem2[0], searchProblem2[12]);

            // Search #3 (Start A: , Goal: G)
            var searchProblem3 = streetGraph.MapStreetGraph();
            shortestPath.search(searchProblem3[1], searchProblem3[6]);

            // A* search engine 
        }
    }
}
