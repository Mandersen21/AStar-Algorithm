using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Searching
{
    public class ShortestStreetPath
    {
        // Searching using the Astar algorithm
        public void search(StreetCorner root, StreetCorner goal)
        {
            Console.WriteLine("Searchproblem: " + "Start node: " + root.name + "    Goal node: " + goal.name);
            Console.WriteLine("");

            SearchHelper sh = new SearchHelper();

            SimplePriorityQueue<StreetCorner> openList = new SimplePriorityQueue<StreetCorner>();
            List<StreetCorner> closedList = new List<StreetCorner>();

            // Cost to be calculted from start to current node
            double tentative_g_score = 0;

            // Put starting node into openList
            openList.Enqueue(root, Convert.ToSingle(root.f_score));

            // Inizialize currentNode object
            StreetCorner currentNode = root;

            while (openList.Count > 0)
            {
                currentNode = openList.Dequeue();

                currentNode.visited = true;
                closedList.Add(currentNode);

                // If goal has been found
                if (currentNode.Equals(goal))
                {
                    // Print goal
                    reconstruct_path(root, goal);
                    break;
                }

                // Calculate g cost from current and set parent
                foreach (var neighbor in currentNode.neighbors)
                {
                    if (closedList.Contains(neighbor.node))
                    {
                        // Skip node if it has been visited before
                        continue;
                    }

                    // The distance from start to a neighbor
                    tentative_g_score = currentNode.getG_score() + neighbor.node.calculate_G_Cost(currentNode);

                    if (!openList.Contains(neighbor.node))
                    {
                        openList.Enqueue((StreetCorner)neighbor.node, Convert.ToSingle(root.f_score));
                    }
                    else if (tentative_g_score >= neighbor.node.g_score)
                    {
                        continue;
                    }

                    // This path is the best so far
                    neighbor.node.parent = currentNode;

                    // Calculate and set g, h, and f values for neighbor
                    neighbor.node.g_score = tentative_g_score;
                    neighbor.node.h_score = calculateHeuristic((StreetCorner)neighbor.node, goal);
                    neighbor.node.f_score = neighbor.node.g_score + neighbor.node.h_score;
                }

            }
        }

        public void reconstruct_path(StreetCorner root, StreetCorner goal)
        {
            // Print values from goal node
            Console.WriteLine(" ");
            Console.Write("The shortest path are calculated to: \n");

            List<StreetCorner> path = new List<StreetCorner>();
            for (StreetCorner node = goal; node != null; node = (StreetCorner)node.parent)
            {
                path.Add(node);
            }

            path.Reverse();

            foreach (StreetCorner node in path)
            {
                if (node == root)
                {
                    Console.WriteLine("Node " + node.name + " - : F: " + node.f_score + "                G: " + node.g_score + "                H: " + node.h_score);
                }
                else
                {
                    Console.WriteLine("Node " + node.name + " - : F: " + node.f_score + " G: " + node.g_score + " H: " + node.h_score);
                }
            }

            foreach (StreetCorner node in path)
            {
                if (node == goal) Console.Write(node.name);
                else
                {
                    Console.Write(node.name + "---");
                }

            }

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }

        // Calculating heuristic distance from node n to goal with pythagoras. 
        public double calculateHeuristic(StreetCorner target, StreetCorner goal)
        {
            return Math.Sqrt((goal.x - target.x) * (goal.x - target.x) + (goal.y - target.y) * (goal.y - target.y));
        }

    }
}
