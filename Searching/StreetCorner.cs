using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class StreetCorner : AbstractNode
    {
        public List<AbstractEdge> neighbors = new List<AbstractEdge>(); // succesors to current node

        public StreetCorner(string name, int x, int y) : base(name, x, y)
        {
            
        }
    }
}
