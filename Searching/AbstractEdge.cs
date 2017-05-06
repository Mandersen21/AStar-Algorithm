using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public abstract class AbstractEdge
    {
        public AbstractNode node { get; set; }
        public string name { get; set; }

        public AbstractEdge(AbstractNode n, string name)
        {
            this.node = n;
            this.name = name;
        }

        public AbstractEdge(string literal)
        {
            this.name = literal;
        }
    }
}
