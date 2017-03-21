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

            // Put starting node into openList
            openList.Enqueue(root, Convert.ToSingle(root.f_score));

            // Inizialize currentNode object
            StreetCorner currentNode = root;

            //Console.WriteLine("Node " + currentNode.name + " - : F: " + currentNode.f_score + "                G: " + currentNode.g_score + "                H: " + currentNode.h_score);

            while (openList.Count > 0)
            {
                currentNode = openList.Dequeue();
                currentNode.visited = true;

                if (currentNode.Equals(goal))
                {
                    // Print goal
                    reconstruct_path(goal);
                    break;
                }

                // Calculate g cost from current and set parent
                foreach (var neighbor in currentNode.neighbors)
                {
                    neighbor.node.calculate_G_Cost(currentNode);                                      // Calculate G
                    neighbor.node.h_score = calculateHeuristic((StreetCorner) neighbor.node, goal);   // Calculate H
                    neighbor.node.f_score = (neighbor.node.g_score + neighbor.node.h_score);            // Calculate F

                    // Add parent if neighbor has not been visited
                    if (!neighbor.node.visited)
                    {
                        neighbor.node.parent = currentNode;
                    }

                    // If neighbor node is in openList
                    if (openList.Contains(neighbor.node))
                    {
                        var target = sh.getNodeFromOpenList((StreetCorner)neighbor.node, openList);

                        if (target.f_score < neighbor.node.f_score)
                        {
                            continue;
                        }
                    }

                    // If neighbor node is in closedList
                    if (closedList.Contains(neighbor.node))
                    {
                        var target = sh.getNodeFromClosedList((StreetCorner)neighbor.node, closedList);

                        if (target.f_score < neighbor.node.f_score)
                        {
                            continue;
                        }
                    }

                    openList.Enqueue((StreetCorner)neighbor.node, Convert.ToSingle(neighbor.node.f_score));
                }

                closedList.Add(currentNode);

                if (currentNode.name != root.name)
                {
                    Console.WriteLine("Node " + currentNode.name + " - : F: " + currentNode.f_score + " G: " + currentNode.g_score + " H: " + currentNode.h_score);
                }
            }
        }

        public void reconstruct_path(StreetCorner goal)
        {
            // Print values from goal node
            Console.WriteLine("Node " + goal.name + " - : F: " + goal.f_score + " G: " + goal.g_score + " H: " + goal.h_score);
            Console.WriteLine(" ");
            Console.Write("The shortest path are calculated to: ");

            List<StreetCorner> path = new List<StreetCorner>();
            for (StreetCorner node = goal; node != null; node = (StreetCorner) node.parent)
            {
                path.Add(node);
            }

            path.Reverse();

            foreach (StreetCorner node in path)
            {
                if (node == goal) Console.Write(node.name);
                else Console.Write(node.name + "---");
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
