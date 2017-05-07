using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public abstract class AbstractNode
    {
        public string name { get; private set; } // name of the current node
        public AbstractNode parent { get; set; } // parent to the current node
        public bool visited { get; set; }        // If it has been visited before
        public int x { get; set; }               // x cordinate
        public int y { get; set; }               // y cordinate
        public double g_score { get; set; }      // distance from start to current node
        public double h_score { get; set; }      // heuristic distance from this node to goal
        public double f_score { get; set; }      // distance from start to current node + Heuristic distance to goal node

        //public List<String> clause = new List<String>(); // each list is equal to a whole clause.
        public AbstractNode(string name, int x, int y)
        {
            this.name = name;
            this.x = x;
            this.y = y;
        }

        public AbstractNode(string name)
        {
            this.name = name;
        }

        public double calculate_G_Cost(AbstractNode other)
        {
            var g_score = Math.Sqrt((x - other.x) * (x - other.x) + (y - other.y) * (y - other.y));
            return g_score;
        }

        public void calculate_F_Cost()
        {
            f_score = g_score + h_score;
        }

        public double getG_score()
        {
            return g_score;
        }

        public double GetH_score()
        {
            return h_score;
        }

        public double GetF_score()
        {
            return f_score;
        }
    }
}
