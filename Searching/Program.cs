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

            //// Search #1 (Start A: , Goal: G)
            var searchProblem1 = streetGraph.MapStreetGraph();
            shortestPath.search(searchProblem1[0], searchProblem1[6]);

            //// Search #2 (Start A: , Goal: M)
            //var searchProblem2 = streetGraph.MapStreetGraph();
            //shortestPath.search(searchProblem2[0], searchProblem2[12]);

            // Search #3 (Start A: , Goal: N)
            //var searchProblem3 = streetGraph.MapStreetGraph();
            //shortestPath.search(searchProblem3[1], searchProblem3[13]);

            // A* search inferens engine 
            //BuildKnowledgeBase knowledgebase = new BuildKnowledgeBase();
            //InferensEngine engine = new InferensEngine();

            // Build knowledgebase
            //var KB = knowledgebase.MapKnowledgeBase();

            //// Build clause to proof
            //var alpha = new Clause("A", new List<String> { "~a" });

            //// Print knowledgebase
            //Console.WriteLine("Knowledgebase:");
            //foreach (var k in KB)
            //{
            //    Console.Write("Clause: ");
            //    foreach (var letter in k.clause)
            //    { Console.Write(letter + " "); }
            //    Console.Write("\n");
            //}

            //// Print proof clause
            //Console.Write("Clause to proof: ");
            //foreach (var letters in alpha.clause)
            //{
            //    Console.Write("a");
            //}
            //Console.Write("\n");

            ////Console.WriteLine("\n");
            //engine.inferens_proofer(KB, alpha);
        }
    }
}
