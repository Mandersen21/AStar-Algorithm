using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class Clause : AbstractNode
    {
        public List<Literal> clauseLiterals = new List<Literal>(); // literals on current clause

        public Clause(string name) : base(name)
        {

        }
    }
}
