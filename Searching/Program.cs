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

            // Search #1 (Start A: , Goal: G)
            var searchProblem1 = streetGraph.MapStreetGraph();
            shortestPath.search(searchProblem1[0], searchProblem1[6]);

            //// Search #2 (Start A: , Goal: M)
            //var searchProblem2 = streetGraph.MapStreetGraph();
            //shortestPath.search(searchProblem2[0], searchProblem2[12]);

            // Search #3 (Start A: , Goal: N)
            //var searchProblem3 = streetGraph.MapStreetGraph();
            //shortestPath.search(searchProblem3[1], searchProblem3[13]);

            // A* search inferens engine 
            BuildKnowledgeBase knowledgebase = new BuildKnowledgeBase();
            InferenceEngine engine = new InferenceEngine();

            // Build knowledgebase
            var KB = knowledgebase.MapKnowledgeBase();
            var counter = 0;
            
            // Build clause to proof
            var alpha = new Clause("A");
            var goal = new Clause("Goal");

            alpha.clauseLiterals = new List<Literal>
            {
                new Literal("~a")
            };

            goal.clauseLiterals = new List<Literal> {
                new Literal("[]")
            };

            // Print knowledgebase
            Console.WriteLine("Knowledgebase");

            foreach (var clause in KB)
            {
                Console.Write(counter + ": ");
                foreach (var literal in clause.clauseLiterals)
                {
                    Console.Write(literal.name + " ");
                }
                Console.Write("\n");
                counter++;
            }

            Console.WriteLine("-------------------------");
            Console.Write("proof: a");
            Console.WriteLine("\n-------------------------");
            Console.Write("\n");

            engine.inference_proofer_search(KB, alpha, goal);
        }
    }
}
